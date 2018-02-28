using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WillClinic.Models;

namespace WillClinicTestBattery
{
    public class ModelIntakeForm
    {
        // Testing isNotarized
        // Testing TermsAndConditions

        // Testing FullLegalName
        [Fact]
        public void Name_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.FullLegalName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FullLegalName);
        }

        [Fact]
        public void Name_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { FullLegalName = "Lawyer" };

            // Act
            n.FullLegalName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FullLegalName);
        }

        // Testing Address
        [Fact]
        public void Address_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.Address = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.Address);
        }

        [Fact]
        public void Address_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { Address = "Lawyer" };

            // Act
            n.Address = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.Address);
        }

        // Testing . . .

        // Testing Marital Status
        [Fact]
        public void MaritalStatus_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.MaritalStatus = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.MaritalStatus);
        }

        [Fact]
        public void MaritalStatus_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { Address = "Lawyer" };

            // Act
            n.MaritalStatus = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.MaritalStatus);
        }

        // Testing FullNameSpouse
        [Fact]
        public void FullNameSpouse_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.FullNameSpouse = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FullNameSpouse);
        }

        [Fact]
        public void FullNameSpouse_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { FullNameSpouse = "Lawyer" };

            // Act
            n.FullNameSpouse = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FullNameSpouse);
        }

        // Testing MinorChildrenDifferentSpouse
        [Fact]
        public void MinorChildrenDifferentSpouse_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.MinorChildrenDifferentSpouse = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.MinorChildrenDifferentSpouse);
        }

        [Fact]
        public void MinorChildrenDifferentSpouse_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { MinorChildrenDifferentSpouse = "Lawyer" };

            // Act
            n.MinorChildrenDifferentSpouse = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.MinorChildrenDifferentSpouse);
        }

        // Testing BequestInfromation
        [Fact]
        public void BequestInfromation_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.BequestInfromation = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.BequestInfromation);
        }

        [Fact]
        public void BequestInfromation_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { BequestInfromation = "Lawyer" };

            // Act
            n.BequestInfromation = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.BequestInfromation);
        }

        // Testing InheritEstateSpecific
        [Fact]
        public void InheritEstateSpecific_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.InheritEstateSpecific = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.InheritEstateSpecific);
        }

        [Fact]
        public void InheritEstateSpecific_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { InheritEstateSpecific = "Lawyer" };

            // Act
            n.InheritEstateSpecific = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.InheritEstateSpecific);
        }

        // Testing RemainderBeneficiarySpecific
        [Fact]
        public void RemainderBeneficiarySpecific_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.RemainderBeneficiarySpecific = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.RemainderBeneficiarySpecific);
        }

        [Fact]
        public void RemainderBeneficiarySpecific_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { RemainderBeneficiarySpecific = "Lawyer" };

            // Act
            n.RemainderBeneficiarySpecific = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.RemainderBeneficiarySpecific);
        }

        // Testing DisinherentDescription
        [Fact]
        public void DisinheritDescription_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.DisinheritDescription = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.DisinheritDescription);
        }

        [Fact]
        public void DisinheritDescription_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { DisinheritDescription = "Lawyer" };

            // Act
            n.DisinheritDescription = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.DisinheritDescription);
        }

        // Testing PrimaryGuardian
        [Fact]
        public void PrimaryGuardian_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.PrimaryGuardian = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PrimaryGuardian);
        }

        [Fact]
        public void PrimaryGuardian_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { PrimaryGuardian = "Lawyer" };

            // Act
            n.PrimaryGuardian = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PrimaryGuardian);
        }

        // Testing AlternateGuardian
        [Fact]
        public void AlternateGuardian_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.AlternateGuardian = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.AlternateGuardian);
        }

        [Fact]
        public void AlternateGuardian_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { AlternateGuardian = "Lawyer" };

            // Act
            n.AlternateGuardian = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.AlternateGuardian);
        }

        // Testing PersonalRepresentative
        [Fact]
        public void PersonalRepresentative_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.PersonalRepresentative = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PersonalRepresentative);
        }

        [Fact]
        public void PersonalRepresentative_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { PersonalRepresentative = "Lawyer" };

            // Act
            n.PersonalRepresentative = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PersonalRepresentative);
        }

        // Testing AlternateRepresentative
        [Fact]
        public void AlternateRepresentative_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.AlternateRepresentative = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.AlternateRepresentative);
        }

        [Fact]
        public void AlternateRepresentative_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { AlternateRepresentative = "Lawyer" };

            // Act
            n.AlternateRepresentative = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.AlternateRepresentative);
        }

        // Testing PrimaryAttorney
        [Fact]
        public void PrimaryAttorney_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.PrimaryAttorney = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PrimaryAttorney);
        }

        [Fact]
        public void PrimaryAttorney_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { PrimaryAttorney = "Lawyer" };

            // Act
            n.PrimaryAttorney = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PrimaryAttorney);
        }

        // Testing AlternateAttorney
        [Fact]
        public void AlternateAttorney_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.AlternateAttorney = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.AlternateAttorney);
        }

        [Fact]
        public void AlternateAttorney_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { AlternateAttorney = "Lawyer" };

            // Act
            n.AlternateAttorney = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.AlternateAttorney);
        }


    }
}
