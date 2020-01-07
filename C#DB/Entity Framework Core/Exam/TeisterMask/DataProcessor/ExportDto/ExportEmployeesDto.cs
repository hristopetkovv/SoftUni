namespace TeisterMask.DataProcessor.ExportDto
{

    public class ExportEmployeesDto
    {
        public string Username { get; set; }

        public ExportTaskEmployeeDto[] Tasks { get; set; }
    }
}
