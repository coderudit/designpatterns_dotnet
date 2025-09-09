namespace solid_design_principles.isp
{
    internal class ContractEmployee : IHourlyPaid
    {
        private decimal hourlyRate;
        private int hoursWorked;

        public ContractEmployee(decimal hourlyRate, int hoursWorked)
        {
            this.hourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
        }

        public decimal CalculateHourlySalary()
        {
            return hourlyRate * hoursWorked;
        }
    }
}