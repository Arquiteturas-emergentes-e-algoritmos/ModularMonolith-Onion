using MedicationPlan.Application.Command;
using MedicationPlan.Domain;

namespace MedicationPlan.Tests.Commands
{
    [TestClass]
    public class MedicationPlanCommandTests
    {
        [DataTestMethod]
        [DataRow("", "0001-01-01", "00000000-0000-0000-0000-000000000000", false)]
        [DataRow("Aspirin", "0001-01-01", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
        [DataRow("", "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
        [DataRow("Aspirin", "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", true)]
        public void AddMedicationCommand_Validate_ShouldReturnExpectedResult(string name, string takeAt, string medicationPlanId, bool expected)
        {
            var command = new AddMedicationCommand
            {
                MedicationPlanId = Guid.Parse(medicationPlanId),
                Name = name,
                TakeAt = DateTime.Parse(takeAt)
            };

            var result = command.Validate();

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("00000000-0000-0000-0000-000000000000", false)]
        [DataRow("f7dfd3c7-8080-41ef-b6b3-d1bfc93f0c7c", true)]
        public void DeleteMedicationCommand_Validate_ShouldReturnExpectedResult(string medicationPlanId, bool expected)
        {
            var command = new DeleteMedicationCommand
            {
                MedicationPlanId = Guid.NewGuid(),
                MedicationId = Guid.Parse(medicationPlanId)
            };

            var result = command.Validate();

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("", "0001-01-01", "00000000-0000-0000-0000-000000000000", false)]
        [DataRow("Ibuprofen", "0001-01-01", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
        [DataRow("", "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
        [DataRow("Ibuprofen", "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", true)]
        public void UpdateMedicationCommand_Validate_ShouldReturnExpectedResult(string name, string takeAt, string medicationPlanId, bool expected)
        {
            var medication = new Medication { Name = name, TakeAt = DateTime.Parse(takeAt) };
            var command = new UpdateMedicationCommand
            {
                MedicationPlanId = Guid.Parse(medicationPlanId),
                Medication = medication
            };

            var result = command.Validate();

            Assert.AreEqual(expected, result);
        }
    }
}
