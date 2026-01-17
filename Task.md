
# 📘 Probeprüfung OOP – _Event Booking System_

You are building a small domain model for an **Event Booking System**.  
The system manages events, participants, venues, and sponsors.

---

## 🔹 Aufgabe 1 – UML-Umsetzung

Implement the following UML structure in C#.

Classes:

- `Event`
    
- `OnlineEvent : Event`
    
- `OnSiteEvent : Event`
    
- `Attendee`
    
- `IndividualAttendee : Attendee`
    
- `GroupAttendee : Attendee`
    

Associations:

- An `Event` has **multiple Attendees** (`0..*` – _participates_).
    
- An `Event` has **at most one Attendee** as _winner_ (`0..1` – _awarded to_).
    

There is a **SUBSET restriction**:

> Only an Attendee that _participates_ in an Event may be _awarded_.

Implement this restriction in the method:

```
SetWinner(attendee : Attendee) : bool
```

- Return `true` if the assignment was successful
    
- Return `false` otherwise
    

---

## 🔹 Aufgabe 2 – Regeln & Verhalten

Extend your classes with the following requirements:

1. Every `Event` must have a **title** (mandatory).
    
2. An `Event` may have a **date** (optional).
    
3. After creation, Attendees can be added.
    
4. `OnlineEvent`:
    
    - Only `IndividualAttendee` may participate.
        
    - Each attendee must have an **email address**.
        
5. `OnSiteEvent`:
    
    - Only `GroupAttendee` may participate.
        
    - Each group must have a **minimum** and **maximum** size.
        

---

## 🔹 Aufgabe 3 – Partners

An `Event` can have **multiple Partners**.

There are three types of partners:

- `PremiumSponsor`
    
- `StandardSponsor`
    
- `MediaPartner`
    

Rules:

- Sponsors (`PremiumSponsor`, `StandardSponsor`) have a **budget**.
    
- If budget ≥ 20’000 → Premium
    
- Otherwise → Standard
    
- A `MediaPartner` has a **ChannelType**:
    
    - Print
        
    - TV
        
    - Radio
        
    - SocialMedia
        

Each Partner has **ContactInformation**:

- Name
    
- Email
    
- Phone
    

---

## 🔹 Aufgabe 4 – Groups & Constraints

A `GroupAttendee` consists of **multiple IndividualAttendees**.

- Groups must manage their members.
    
- `OnSiteEvent` defines:
    
    - `minGroupSize`
        
    - `maxGroupSize`
        

Only groups whose size is within this range may be added to an `OnSiteEvent`.

