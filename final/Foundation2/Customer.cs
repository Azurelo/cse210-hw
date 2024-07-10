class Customer
{
    private string _name;
    private Address address;

    public Customer(string name, Address address)
    {
        _name = name;
        this.address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}