using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WillClinic.Models;

namespace WillClinicTestBattery
{
    public class ModelIntakeForm
    {
        // Testing IsNotarized
        [Fact]
        public void IsNotarized_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();


            // Act
            n.IsNotarized = true;
            parent.IsNotarized = true;

            // Assert
            Assert.True(n.IsNotarized);
            Assert.True(parent.IsNotarized);
        }


        [Fact]
        public void IsNotarized_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { IsNotarized = false };

            // Act
            n.IsNotarized = true;

            // Assert
            Assert.True(n.IsNotarized);
        }


        // Testing TermsAndConditions
        [Fact]
        public void TermsAndConditions_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();


            // Act
            n.TermsAndConditions = true;
            parent.TermsAndConditions = true;

            // Assert
            Assert.True(n.TermsAndConditions);
            Assert.True(parent.TermsAndConditions);
        }


        [Fact]
        public void TermsAndConditions_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { TermsAndConditions = false };

            // Act
            n.TermsAndConditions = true;

            // Assert
            Assert.True(n.TermsAndConditions);
        }

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

        // Testing PhoneNumber
        [Fact]
        public void PhoneNumber_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.PhoneNumber = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PhoneNumber);
        }

        [Fact]
        public void PhoneNumber_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { PhoneNumber = "Lawyer" };

            // Act
            n.PhoneNumber = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.PhoneNumber);
        }

        // Testing VeteranStatus
        [Fact]
        public void VeteranStatus_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.VeteranStatus = true;
            parent.VeteranStatus = true;

            // Assert
            Assert.True(n.VeteranStatus);
            Assert.True(parent.VeteranStatus);
        }


        [Fact]
        public void VeteranStatus_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { VeteranStatus = false };

            // Act
            n.VeteranStatus = true;

            // Assert
            Assert.True(n.VeteranStatus);
        }

        // Testing ProofOfService
        [Fact]
        public void ProofOfService_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.ProofOfService = true;
            parent.ProofOfService = true;

            // Assert
            Assert.True(n.ProofOfService);
            Assert.True(parent.ProofOfService);
        }


        [Fact]
        public void ProofOfService_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { ProofOfService = false };

            // Act
            n.ProofOfService = true;

            // Assert
            Assert.True(n.ProofOfService);
        }

        // Testing ResidentStatus
        [Fact]
        public void ResidentStatus_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.ResidentStatus = true;
            parent.ResidentStatus = true;

            // Assert
            Assert.True(n.ResidentStatus);
            Assert.True(parent.ResidentStatus);
        }


        [Fact]
        public void ResidentStatus_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { ResidentStatus = false };

            // Act
            n.ResidentStatus = true;

            // Assert
            Assert.True(n.ResidentStatus);
        }


        // Testing NetWorth
        [Fact]
        public void NetWorth_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.NetWorth = true;
            parent.NetWorth = true;

            // Assert
            Assert.True(n.NetWorth);
            Assert.True(parent.NetWorth);
        }


        [Fact]
        public void NetWorth_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { NetWorth = false };

            // Act
            n.NetWorth = true;

            // Assert
            Assert.True(n.NetWorth);
        }

        // Testing BankAccountAssets
        [Fact]
        public void BankAccountAssets_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.BankAccountAssets = 5;

            // Assert
            Assert.Equal(5, n.BankAccountAssets);
        }

        [Fact]
        public void BankAccountAssets_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { BankAccountAssets = 9 };

            // Act
            n.BankAccountAssets = 10;

            // Assert
            Assert.Equal(10, n.BankAccountAssets);
        }

        // Testing RealEstateAssets
        [Fact]
        public void RealEstateAssets_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.RealEstateAssets = 5;

            // Assert
            Assert.Equal(5, n.RealEstateAssets);
        }

        [Fact]
        public void RealEstateAssets_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { RealEstateAssets = 9 };

            // Act
            n.RealEstateAssets = 10;

            // Assert
            Assert.Equal(10, n.RealEstateAssets);
        }

        // Testing BankAccountAssets
        [Fact]
        public void LifeInsuranceCashValue_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.LifeInsuranceCashValue = 5;

            // Assert
            Assert.Equal(5, n.LifeInsuranceCashValue);
        }

        [Fact]
        public void LifeInsuranceCashValue_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { LifeInsuranceCashValue = 9 };

            // Act
            n.LifeInsuranceCashValue = 10;

            // Assert
            Assert.Equal(10, n.LifeInsuranceCashValue);
        }

        // Testing RetirementAccounts
        [Fact]
        public void RetirementAccounts_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.RetirementAccounts = 5;

            // Assert
            Assert.Equal(5, n.RetirementAccounts);
        }

        [Fact]
        public void RetirementAccounts_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { RetirementAccounts = 9 };

            // Act
            n.RetirementAccounts = 10;

            // Assert
            Assert.Equal(10, n.RetirementAccounts);
        }

        // Testing StockBonds
        [Fact]
        public void StockBonds_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.StockBonds = 5;

            // Assert
            Assert.Equal(5, n.StockBonds);
        }

        [Fact]
        public void StockBonds_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { StockBonds = 9 };

            // Act
            n.StockBonds = 10;

            // Assert
            Assert.Equal(10, n.StockBonds);
        }

        // Testing Pension
        [Fact]
        public void Pension_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.Pension = 5;

            // Assert
            Assert.Equal(5, n.Pension);
        }

        [Fact]
        public void Pension_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { Pension = 9 };

            // Act
            n.Pension = 10;

            // Assert
            Assert.Equal(10, n.Pension);
        }

        // Testing BusinessInterest
        [Fact]
        public void BusinessInterest_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.BusinessInterest = 5;

            // Assert
            Assert.Equal(5, n.BusinessInterest);
        }

        [Fact]
        public void BusinessInterest_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { BusinessInterest = 9 };

            // Act
            n.BusinessInterest = 10;

            // Assert
            Assert.Equal(10, n.BusinessInterest);
        }

        // Testing MoneyOwedToYou
        [Fact]
        public void MoneyOwedToYou_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.MoneyOwedToYou = 5;

            // Assert
            Assert.Equal(5, n.MoneyOwedToYou);
        }

        [Fact]
        public void MoneyOwedToYou_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { MoneyOwedToYou = 9 };

            // Act
            n.MoneyOwedToYou = 10;

            // Assert
            Assert.Equal(10, n.MoneyOwedToYou);
        }

        // Testing OtherAssetsOrMoney
        [Fact]
        public void OtherAssetsOrMoney_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.OtherAssetsOrMoney = 5;

            // Assert
            Assert.Equal(5, n.OtherAssetsOrMoney);
        }

        [Fact]
        public void OtherAssetsOrMoney_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { Pension = 9 };

            // Act
            n.OtherAssetsOrMoney = 10;

            // Assert
            Assert.Equal(10, n.OtherAssetsOrMoney);
        }

        // Testing HouseHoldSize 
        [Fact]
        public void HouseHoldSize_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.HouseHoldSize = 5;

            // Assert
            Assert.Equal(5, n.HouseHoldSize);
        }

        [Fact]
        public void HouseHoldSize_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { HouseHoldSize = 9 };

            // Act
            n.HouseHoldSize = 10;

            // Assert
            Assert.Equal(10, n.HouseHoldSize);
        }

        // Testing MonthlyIncome
        [Fact]
        public void MonthlyIncome_TestingGetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.MonthlyIncome = 5;

            // Assert
            Assert.Equal(5, n.MonthlyIncome);
        }

        [Fact]
        public void MonthlyIncome_TestingSetter_ReturnLong()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { MonthlyIncome = 9 };

            // Act
            n.MonthlyIncome = 10;

            // Assert
            Assert.Equal(10, n.MonthlyIncome);
        }


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

        // Testing HaveChildren
        [Fact]
        public void HaveChildren_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.HaveChildren = true;
            parent.HaveChildren = true;

            // Assert
            Assert.True(n.HaveChildren);
            Assert.True(parent.HaveChildren);
        }


        [Fact]
        public void HaveChildren_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { HaveChildren = false };

            // Act
            n.HaveChildren = true;

            // Assert
            Assert.True(n.HaveChildren);
        }

        // Testing UnderAgeChildren
        [Fact]
        public void UnderAgeChildren_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.UnderAgeChildren = true;
            parent.UnderAgeChildren = true;

            // Assert
            Assert.True(n.UnderAgeChildren);
            Assert.True(parent.UnderAgeChildren);
        }


        [Fact]
        public void UnderAgeChildren_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { UnderAgeChildren = false };

            // Act
            n.UnderAgeChildren = true;

            // Assert
            Assert.True(n.UnderAgeChildren);
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

        // Testing CurrentlyPregnant
        [Fact]
        public void CurrentlyPregnant_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.CurrentlyPregnant = true;
            parent.CurrentlyPregnant = true;

            // Assert
            Assert.True(n.CurrentlyPregnant);
            Assert.True(parent.CurrentlyPregnant);
        }


        [Fact]
        public void CurrentlyPregnant_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { CurrentlyPregnant = false };

            // Act
            n.CurrentlyPregnant = true;

            // Assert
            Assert.True(n.CurrentlyPregnant);
        }

        // Testing SpecificBequest
        [Fact]
        public void SpecificBequest_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.SpecificBequest = true;
            parent.SpecificBequest = true;

            // Assert
            Assert.True(n.SpecificBequest);
            Assert.True(parent.SpecificBequest);
        }


        [Fact]
        public void SpecificBequest_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { SpecificBequest = false };

            // Act
            n.SpecificBequest = true;

            // Assert
            Assert.True(n.SpecificBequest);
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

        // Testing DisinheritSomeone
        [Fact]
        public void DisinheritSomeone_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.DisinheritSomeone = true;
            parent.DisinheritSomeone = true;

            // Assert
            Assert.True(n.DisinheritSomeone);
            Assert.True(parent.DisinheritSomeone);
        }


        [Fact]
        public void DisinheritSomeone_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { DisinheritSomeone = false };

            // Act
            n.DisinheritSomeone = true;

            // Assert
            Assert.True(n.DisinheritSomeone);
        }

        // Testing DisinheretDescription
        [Fact]
        public void DisinheretDescription_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();

            // Act
            n.DisinheretDescription = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.DisinheretDescription);
        }

        [Fact]
        public void DisinheretDescription_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { DisinheretDescription = "Lawyer" };

            // Act
            n.DisinheretDescription = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.DisinheretDescription);
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

        // Testing RequestPowerOfAttorney
        [Fact]
        public void RequestPowerOfAttorney_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.RequestPowerOfAttorney = true;
            parent.RequestPowerOfAttorney = true;

            // Assert
            Assert.True(n.RequestPowerOfAttorney);
            Assert.True(parent.RequestPowerOfAttorney);
        }


        [Fact]
        public void RequestPowerOfAttorney_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { RequestPowerOfAttorney = false };

            // Act
            n.RequestPowerOfAttorney = true;

            // Assert
            Assert.True(n.RequestPowerOfAttorney);
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

        // Testing HealthCareDirective
        [Fact]
        public void HealthCareDirective_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.HealthCareDirective = true;
            parent.HealthCareDirective = true;

            // Assert
            Assert.True(n.HealthCareDirective);
            Assert.True(parent.HealthCareDirective);
        }


        [Fact]
        public void HealthCareDirective_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { HealthCareDirective = false };

            // Act
            n.HealthCareDirective = true;

            // Assert
            Assert.True(n.HealthCareDirective);
        }

        // Testing HydrationDirective
        [Fact]
        public void HydrationDirective_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.HydrationDirective = true;
            parent.HydrationDirective = true;

            // Assert
            Assert.True(n.HydrationDirective);
            Assert.True(parent.HydrationDirective);
        }


        [Fact]
        public void HydrationDirective_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { HydrationDirective = false };

            // Act
            n.HydrationDirective = true;

            // Assert
            Assert.True(n.HydrationDirective);
        }

        // Testing NutritionDirective
        [Fact]
        public void NutritionDirective_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.NutritionDirective = true;
            parent.NutritionDirective = true;

            // Assert
            Assert.True(n.NutritionDirective);
            Assert.True(parent.NutritionDirective);
        }


        [Fact]
        public void NutritionDirective_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { NutritionDirective = false };

            // Act
            n.NutritionDirective = true;

            // Assert
            Assert.True(n.NutritionDirective);
        }

        // Testing ArtificialVentilation
        [Fact]
        public void ArtificialVentilation_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.ArtificialVentilation = true;
            parent.ArtificialVentilation = true;

            // Assert
            Assert.True(n.ArtificialVentilation);
            Assert.True(parent.ArtificialVentilation);
        }


        [Fact]
        public void ArtificialVentilation_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { ArtificialVentilation = false };

            // Act
            n.ArtificialVentilation = true;

            // Assert
            Assert.True(n.ArtificialVentilation);
        }

        // Testing DistressMedication
        [Fact]
        public void DistressMedication_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.DistressMedication = true;
            parent.DistressMedication = true;

            // Assert
            Assert.True(n.DistressMedication);
            Assert.True(parent.DistressMedication);
        }


        [Fact]
        public void DistressMedication_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { DistressMedication = false };

            // Act
            n.DistressMedication = true;

            // Assert
            Assert.True(n.DistressMedication);
        }

        // Testing IsCompleted
        [Fact]
        public void IsCompleted_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm();
            VeteranIntakeForm parent = new VeteranIntakeForm();

            // Act
            n.IsCompleted = true;
            parent.IsCompleted = true;

            // Assert
            Assert.True(n.IsCompleted);
            Assert.True(parent.IsCompleted);
        }


        [Fact]
        public void IsCompleted_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranIntakeForm n = new VeteranIntakeForm() { IsCompleted = false };

            // Act
            n.IsCompleted = true;

            // Assert
            Assert.True(n.IsCompleted);
        }


    }
}
