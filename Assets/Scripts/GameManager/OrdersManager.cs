using Assets.Code;
using AutoFixture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Bogus;


public class  ContractsManager : MonoBehaviour 
{
    private Contract current = null;
    public Contract CurrentContract { get => current; set => current = value; }


    public event EventHandler<Contract> ContractCompleted;
    public event EventHandler<Contract> ContractCanceled;

    public List<Contract> CurrentContracts;
    public AudioSource ContractCompletedSource;
    public PlayerInventory PlayerInventory;

    private void OnContractCompleted(object src, Contract e)
    {
        ContractCompletedSource.Play();
        PlayerInventory.Money += CurrentContract.Order.Value;
        CurrentContract = null;
    }


    public void CompleteContract()
    {
        ContractCompleted?.Invoke(this, CurrentContract);
    }

    public void CancelContract()
    {
        ContractCanceled?.Invoke(this, CurrentContract);
        CurrentContract = null;
    }

}

//todo rename to contracts manager
//todo add a separate contracts manager
// this should be used for making orders instead of completing contracts
public class OrdersManager : MonoBehaviour
{
    public List<Order> Orders;
    private Contract current = null;
    public Contract CurrentContract { get => current; set => current = value; }
    public int OrdersToGenerate;

    public List<Contract> CurrentContracts;
    public AudioSource ContractCompletedSource;
    public PlayerInventory PlayerInventory;

    public TruckFactory TruckFactory;

    public event EventHandler<Contract> ContractCompleted;
    public event EventHandler<Contract> ContractCanceled;
    public event EventHandler<Order> OrderAdded;

    public PrintModelDatabase PrintModelDatabase;   
    public GameObject DeliveryBoxSpawn;

    private Fixture _fixture = new();
    private Faker _faker = new();

    public void BeginDelivery()
    {
        var truck = TruckFactory.SpawnTruck();
        truck.OrdersManager = this;
    }

    private void OnContractCompleted(object src, Contract e)
    {
        ContractCompletedSource.Play();
        PlayerInventory.Money += CurrentContract.Order.Value;
        CurrentContract = null;
    }

    public void CompleteContract()
    {
        ContractCompleted?.Invoke(this, CurrentContract);
    }

    public void CancelContract()
    {
        ContractCanceled?.Invoke(this, CurrentContract);
        CurrentContract = null;
    }

    protected virtual void OnOrderAdded(Order order)
    {
        OrderAdded.Invoke(this, order);
    }

    private IEnumerable<Order> GenerateOrders(int amount) => _fixture.CreateMany<Order>(amount);

    public void CreateContract(Order order)
    {
        CurrentContract = new Contract
        {
            Order = order,
            Remaining = order.Amount,
            Recipient = _faker.Name.FullName()
        };

        OrderAdded?.Invoke(this, order);
        CurrentContracts.Add(CurrentContract);
    }

    Fixture CreateFixture()
    {
        var fixture = new Fixture();
        fixture.Customize<Order>(e => e.With(p => p.Amount, () => UnityEngine.Random.Range(3, 6)).With(e => e.PrintModel, () =>
        {
            int i = new System.Random().Next(0, PrintModelDatabase.PrintModels.Count - 1);
            return PrintModelDatabase.PrintModels[i];
        }));

        return fixture;
    }

    // Start is called before the first frame update
    void Start()
    {
        _faker = new();
        _fixture = CreateFixture();
        Orders = GenerateOrders(OrdersToGenerate).ToList();
        ContractCompleted += OnContractCompleted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class Meta
{
    public static List<string> Models = new();

    static Meta()
    {
        Models = new()
        {
            "Bottle",
            "Truck",
            "Cube",
            "Car",
            "Bike",
            "Pot",
            "Bowl"
        };
    }
}
