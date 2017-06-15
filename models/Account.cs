using System;
//using Progress.Open4GL; I suspect that we don't need this

namespace Digital.Models
{
    public class Account
    {

        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string ClientAddress { get; set; }
        public string PostCode { get; set; }
        public DateTime? Dob { get; set; }
        public string ClientDebtCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public DateTime? OpeningDate { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal OriginalBalance { get; set; }
        public decimal TotalPaid { get; set; }
        public DateTime? LastPaid { get; set; }
        public bool HasArrangement { get; set; }
        public decimal AgreementAmount { get; set; }
        public string AgreementTypeId { get; set; }
        public string AgreementTypeName { get; set; }
        public string AgreementFrequency { get; set; }
        public string Client { get; set; }
        public string ClientReference { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool CanSetUpPlan { get; set; }
        public bool CanMakeCardPayment { get; set; }
        public bool CanMakePayment { get; set; }
        public bool CanClearBalanceInSingleCardPayment { get; set; }
        public bool CanSetupCardPlan { get; set; }
        public string ExcludedMessage { get; set; }
        public string Repcode { get; set; }
        public decimal AcceptedDiscountValue { get; set; }
        public DateTime? DiscountExpiry { get; set; }
        public bool CPACoolingOffPeriodRequired { get; set; }
        public DateTime? EarliestInstalment { get; set; }
        public bool HasWebAccount { get; set; }
        public DateTime? MaxPlanStartDate { get; set; }
        public bool InFlightPayment { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal ArrearsBalance { get; set; }
        public bool AutomatedPlanInProgress { get; set; }
        public bool StatBarred { get; set; }
        public bool JointAccount { get; set; }

    }
}