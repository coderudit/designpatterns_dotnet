namespace solid_design_principles.isp
{
    internal class FullTimeEmployee : IMonthlyPaid
    {
        private decimal monthlySalary;

        public FullTimeEmployee(decimal monthlySalary)
        {
            this.monthlySalary = monthlySalary;
        }

        public decimal CalculateMonthlySalary()
        {
            return monthlySalary;
        }
    }
}