using Assets;
using Assets.Code;
using Assets.ScriptableObjects;
using Dummiesman;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PrinterBehaviour
{
    public enum PrintState { Idle, Calibrating, Printing, NoFilament }

    //todo better name
    public class PrintBehaviour : MonoBehaviour
    {
        public bool LoadModelFromDisk = false;
        public GameObject PrintPrefab;
        public Transform SpawnPoint;

        public AudioSource AudioSource;

        public GameObject SpoolHolder; //remove this

        public float TotalFilament;
        public float PrintTime = 3;
        public string PrintStatus;
        public string ScreenMessage;

        public Filament Filament;

        public Renderer PrintMesh;
        public int XpValue = 5;

        public int PrintCount = 0;
        public int CalibrationThreshold = 2;
        public bool Calibrated;
        public float PrintProgress = 0;

        public int PrintCost = 50;

        public UnityEngine.UI.Slider ProgressBar;

        public List<PrintModel> PrintModels;

        public event EventHandler<PrintState> PrintStateChanged;


        //new
        public Mesh MeshToPrint;

        public PrintModel CurrentPrintModel = null;

        public void OnEnable()
        {
            LoadModelFromDisk = false;
        }

        private Dictionary<PrintState, Color> StateColourMap = new Dictionary<PrintState, Color>()
    {
        {PrintState.Idle, Color.white},
        {PrintState.NoFilament, Color.red},
        {PrintState.Calibrating, Color.yellow},
        {PrintState.Printing, Color.green}
    };

        public void SetPrintModel(PrintModel model)
        {
            Debug.Log("Setting model to " + model.name);
            CurrentPrintModel = model;
        }

        private PrintState _state;
        public PrintState State { get { return _state; } set { _state = value; ChangeColor(); PrintStateChanged?.Invoke(this, State); } }
        public string PrintStatus2 { get => $"{State}"; }

        public void Toggle(string status = "")
        {
            StartCoroutine(Calibrate());
        }

        public void ToggleOff()
        {
            // State status accordingly..
            // maybe add pause feature?
        }

        public void AddFilament(float filament) => SetFilament((int)TotalFilament + (int)filament);

        public void SetFilament(Filament filament)
        {
            Filament = filament;

            SetFilament(filament.Amount);
        }

        void ChangeColor() => PrintMesh.material.SetColor("_Color", StateColourMap[_state]);

        public IEnumerator Calibrate()
        {
            if (State == PrintState.Printing || State == PrintState.Calibrating) yield break;

            if (TotalFilament <= 0 || TotalFilament < PrintCost)
            {
                State = PrintState.NoFilament;
                yield break;
            }
            else
            {
                if (PrintCount > CalibrationThreshold || Calibrated == false)
                {
                    State = PrintState.Calibrating;
                    PrintCount = 0;
                    yield return new WaitForSeconds(2);
                    Calibrated = true;
                }

                StartCoroutine(Print());
            }
        }

        public IEnumerator HandleProgressBar(float time)
        {
            var endTime = Time.time + time;

            ProgressBar.minValue = Time.time;
            ProgressBar.maxValue = endTime;

            while (endTime > Time.time)
            {
                ProgressBar.value = Time.time;
                yield return new WaitForSeconds(0.01f);
            }

        }

        public void LoadModelForPrint(GameObject parent)
        {
            using var stream = new FileStream("C:\\Users\\jacko\\OneDrive\\Documents\\Chevrolet_Camaro_SS_Low.obj", FileMode.Open, FileAccess.Read);
            //var textStream = new MemoryStream(Encoding.UTF8.GetBytes("C:\\Users\\jacko\\OneDrive\\Documents\\sdcard.obj"));
            var model = new OBJLoader().Load(stream);
            model.transform.parent = parent.transform;
            model.transform.localPosition = Vector3.zero;
            model.transform.localScale = new Vector3(.25f, .25f, .25f);
        }

        public IEnumerator PrintSounds()
        {
            while (true)
            {
                var test = AudioSource.clip.length;
                var time = UnityEngine.Random.Range(0, test);
                AudioSource.time = time;
                yield return new WaitForSeconds(3);
            }
        }

        public IEnumerator Print()
        {
            if (State == PrintState.Printing || Calibrated == false)
            {
                yield break;
            }

            PrePrint();

            yield return new WaitForSeconds(PrintTime);

            PostPrint();

            yield break;

            void PrePrint()
            {
                State = PrintState.Printing;
                AudioSource.Play();
                StartCoroutine(PrintSounds());
                StartCoroutine(HandleProgressBar(PrintTime));
            }

            void PostPrint()
            {

                var obj = Instantiate(PrintPrefab, SpawnPoint.position, transform.rotation);
                obj.GetComponent<MeshRenderer>().material.color = Filament?.Color ?? Color.white;
                if (CurrentPrintModel != null) 
                    obj.GetComponent<MeshFilter>().mesh = CurrentPrintModel.Mesh;

                if (LoadModelFromDisk)
                {
                    LoadModelForPrint(obj);
                }

                GameObject.Find("Player").GetComponent<PlayerStats>().AddXp(XpValue);
                //TotalFilament -= PrintCost;
                SetFilament((int)TotalFilament - PrintCost);
                State = PrintState.Idle;
                PrintCount++;

                PrintProgress = 0;
                AudioSource.Stop();

                StopCoroutine(PrintSounds());
                StopCoroutine(HandleProgressBar(PrintTime));

                ToastNotificationManager.Instance.Create("Print completed");

                ProgressBar.value = ProgressBar.minValue;
                if (PrintCount >= CalibrationThreshold)
                {
                    Calibrated = false;
                }
            }
        }

        public void SetFilament(int filament)
        {
            TotalFilament = filament;
            if (TotalFilament > 0)
            {
                SpoolHolder.SetActive(true);
            }
            else
            {
                SpoolHolder.SetActive(false);
                State = PrintState.NoFilament;
            }
        }

        private void Start()
        {
            CalibrationThreshold = 2;
            Calibrated = false;
            PrintCost = 50;
            ChangeColor();
            SetFilament(0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tags.Spool)
            {
                //TotalFilament += 350; //todo: filament.amount
                Destroy(other.gameObject);
                SetFilament((int)TotalFilament + 250);
                //SpoolHolder.SetActive(true);
                ChangeColor();
            }
        }
    }

}
