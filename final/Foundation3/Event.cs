class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails() + "\n";
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: {this.GetType().Name}\nTitle: {_title}\nDate: {_date}";
    }
}