namespace Astral.PaymentIntegration.Core.Aggregates
{
    public class Bank
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public bool IsActive { get; private set; }
        public string Currency { get; private set; }
        public virtual ICollection<Payment> Payments { get; private set; }
        public virtual ICollection<Pos> Poses { get; private set; }

        public void Update(string name, string code, bool isActive, string currency)
        {
            Name = name;
            Code = code;
            IsActive = isActive;
            Currency = currency;
        }

        public void AddPos(Pos pos)
        {
            Poses.Add(pos);
        }

        public void SetIsActive()
        {
            IsActive = true;
        }
    }
}
