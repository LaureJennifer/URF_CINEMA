namespace BaseSolution.Domain.Enums
{
    public enum EntityStatus
    {
        Active = 1,
        InActive = 2,
        Deleted = 3,
        Pending = 4,
        PendingForActivation = 5,
        PendingForConfirmation = 6,
        PendingForApproval = 7,
        Locked = 8,
        // Status of seat when booking
        YourSeat = 9,
        Available = 10,
        BeKept = 11,
        SoldOut = 12,
        Reserved = 13,

        //Type of seat
        Standard = 14,
        Vip = 15,
        Couple = 16,
    }
}
