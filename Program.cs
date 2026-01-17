public abstract class Event
{
    public string Title {get;set;}
    public DateTime? Date{get;set;}
    List<Partner> partners = new();
    public Event(string title, DateTime date)
    {
        Title = title;
        Date = date;
    }

    public virtual bool AddAttendee(Attendee attendee)
    {
        attendees.Add(attendee);
        return true;
    }
    List<Attendee> attendees = new List<Attendee>();
    Attendee? winner;

    public bool SetWinner(Attendee attendee)
    {
        if (attendees.Contains(attendee))
        {
            winner = attendee;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void AddPartner(Partner partner)
    {
        partners.Add(partner);
    }
    public Partner CreateSponsor(ContactInfo contactinfo, decimal amount)
    {
        Partner sponsor;
        if (amount >= 20000)
        {
            sponsor = new PremiumSponsor(contactinfo,amount);
        }
        else
        {
            sponsor = new StandardSponsor(contactinfo, amount);
        }
        partners.Add(sponsor);
        return sponsor;
    }

}

public class OnlineEvent : Event
{

    public OnlineEvent(string title, DateTime date) :base(title, date){}
    public override bool AddAttendee(Attendee attendee)
    {
        if(attendee is IndividualAttendee person)
        {
            return base.AddAttendee(attendee);
        }
        return false;
    }
}

public class OnSiteEvent : Event
{
    private int minGroupSize;
    private int maxGroupSize;
    public OnSiteEvent(string title, DateTime date, int min, int max): base(title, date)
    {
        minGroupSize = min;
        maxGroupSize = max;
    }
    public override bool AddAttendee(Attendee attendee)
    {
        if (attendee is GroupAttendee group)
        {
            if (group.Size >= minGroupSize && group.Size <= maxGroupSize)
            {
                return base.AddAttendee(group);
            }
        }
        return false;
    }
}

public abstract class Attendee{}

public class IndividualAttendee : Attendee
{
    public string EmailAddress{get;set;}
    public IndividualAttendee (string emailAddress)
    {
        EmailAddress = emailAddress;
    }
}

public class GroupAttendee : Attendee
{
    public int minSize{get;set;}
    public int maxSize{get;set;}
    List<IndividualAttendee> members = new();
    public GroupAttendee(int minsize, int maxsize) 
    {
        minSize = minsize;
        maxSize = maxsize;
    }
    public void AddMember (IndividualAttendee person)
    {
        members.Add(person);
    }
    public int Size => members.Count;
}

public abstract class Partner 
{
    public decimal Amount{get;set;}
    public ContactInfo contactInfo1;
    public Partner(ContactInfo contactinfo, decimal amount)
    {
        contactInfo1 = contactinfo;
        Amount = amount;
    }
}
public abstract class Sponsor : Partner
{
    public Sponsor(ContactInfo contactinfo, decimal amount) :base( contactinfo, amount){}
}
public class PremiumSponsor : Sponsor
{
    public PremiumSponsor(ContactInfo contactinfo, decimal amount) :base(contactinfo, amount){}
}
public class StandardSponsor : Sponsor
{
    public StandardSponsor(ContactInfo contactinfo, decimal amount) : base(contactinfo, amount){}
}
public class MediaPartner : Partner
{
    public ChannelType channelType1;
    public MediaPartner (ContactInfo contactinfo, ChannelType channeltype1, decimal amount) :base(contactinfo, amount)
    {
        channelType1 = channeltype1;
    }
}