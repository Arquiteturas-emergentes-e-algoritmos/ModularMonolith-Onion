using MedicationPlan.Application.Command;
using MedicationPlan.Application.Repository;
using MedicationPlan.Application.Services;
using MedicationPlan.Domain;
using Moq;

namespace MedicationPlan.Tests
{
    [TestClass]
    public class MedicationPlanServiceTests
    {
        private Mock<IMedicationPlanRepository> _mockRepository;
        private MedicationPlanService _medicationPlanService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IMedicationPlanRepository>();
            _medicationPlanService = new MedicationPlanService(_mockRepository.Object);
        }

        [TestMethod]
        public void Handle_AddMedicationCommand_ShouldAddMedicationAndReturnSuccess()
        {
            // Arrange
            var planId = Guid.NewGuid();
            var command = new AddMedicationCommand { MedicationPlanId = planId, Name = "Aspirin", TakeAt = DateTime.Now };
            var medicationPlan = new MedicationPlan.Domain.MedicationPlan
            {
                Id = planId
            };
            _mockRepository.Setup(repo => repo.GetById(planId)).Returns(medicationPlan);

            // Act
            var response = _medicationPlanService.Handle(command);

            // Assert
            Assert.AreEqual(200, response.Status);
            _mockRepository.Verify(repo => repo.Update(medicationPlan), Times.Once);
        }

        [TestMethod]
        public void Handle_GetMedicationPlanCommand_ShouldReturnMedicationPlan()
        {
            // Arrange
            var planId = Guid.NewGuid();
            var command = new GetMedicationPlanCommand { MedicationPlanId = planId };
            var medicationPlan = new MedicationPlan.Domain.MedicationPlan
            {
                Id = planId
            };
            _mockRepository.Setup(repo => repo.GetById(planId)).Returns(medicationPlan);

            // Act
            var response = _medicationPlanService.Handle(command);

            // Assert
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(medicationPlan, response.Data);
        }

        [TestMethod]
        public void Handle_UpdateMedicationCommand_ShouldUpdateMedicationAndReturnSuccess()
        {
            // Arrange
            var planId = Guid.NewGuid();
            var medication = new Medication("Ibuprofen", DateTime.Now);
            var command = new UpdateMedicationCommand { MedicationPlanId = planId, Medication = medication };
            var medicationPlan = new MedicationPlan.Domain.MedicationPlan
            {
                Id = planId
            };
            _mockRepository.Setup(repo => repo.GetById(planId)).Returns(medicationPlan);

            // Act
            var response = _medicationPlanService.Handle(command);

            // Assert
            Assert.AreEqual(200, response.Status);
            _mockRepository.Verify(repo => repo.Update(medicationPlan), Times.Once);
        }

        [TestMethod]
        public void Handle_DeleteMedicationCommand_ShouldDeleteMedicationAndReturnSuccess()
        {
            // Arrange
            var planId = Guid.NewGuid();
            var medicationId = Guid.NewGuid();
            var command = new DeleteMedicationCommand { MedicationPlanId = planId, MedicationId = medicationId };
            var medicationPlan = new MedicationPlan.Domain.MedicationPlan
            {
                Id = planId
            };
            medicationPlan.AddMedication(new Medication("Paracetamol", DateTime.Now) { Id = medicationId });
            _mockRepository.Setup(repo => repo.GetById(planId)).Returns(medicationPlan);

            // Act
            var response = _medicationPlanService.Handle(command);

            // Assert
            Assert.AreEqual(200, response.Status);
            _mockRepository.Verify(repo => repo.Update(medicationPlan), Times.Once);
        }
    }
}
