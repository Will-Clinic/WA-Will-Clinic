# Database Design

### Veteran Intake Form Table

```sql
    [VeteranApplicationUserId]     NVARCHAR (450)  NOT NULL,
    [Address]                      NVARCHAR (50)   NOT NULL,
    [AlternateAttorney]            NVARCHAR (50)   NULL,
    [AlternateGuardian]            NVARCHAR (50)   NULL,
    [AlternateRepresentative]      NVARCHAR (50)   NULL,
    [ArtificialVentilation]        BIT             NOT NULL,
    [BankAccountAssets]            INT             NOT NULL,
    [BequestInfromation]           NVARCHAR (500)  NULL,
    [BusinessInterest]             INT             NOT NULL,
    [CurrentlyPregnant]            BIT             NOT NULL,
    [DisinherentDescription]       NVARCHAR (75)   NULL,
    [DisinheritSomeone]            BIT             NOT NULL,
    [DistressMedication]           BIT             NOT NULL,
    [FullLegalName]                NVARCHAR (50)   NOT NULL,
    [FullNameSpouse]               NVARCHAR (50)   NOT NULL,
    [HaveChildren]                 BIT             NOT NULL,
    [HealthCareDirective]          BIT             NOT NULL,
    [HouseHoldSize]                INT             NOT NULL,
    [HydrationDirective]           BIT             NOT NULL,
    [ID]                           INT             NOT NULL,
    [InheritEstate]                INT             NOT NULL,
    [InheritEstateSpecific]        NVARCHAR (1000) NULL,
    [IsNotarized]                  BIT             NOT NULL,
    [LifeInsuranceCashValue]       INT             NOT NULL,
    [MaritalStatus]                NVARCHAR (50)   NOT NULL,
    [MinorChildrenDifferentSpouse] NVARCHAR (50)   NOT NULL,
    [MoneyOwedToYou]               INT             NOT NULL,
    [MonthlyIncome]                INT             NOT NULL,
    [NetWorth]                     BIT             NOT NULL,
    [NutritionDirective]           BIT             NOT NULL,
    [OtherAssetsOrMoney]           INT             NOT NULL,
    [Pension]                      INT             NOT NULL,
    [PersonalRepresentative]       NVARCHAR (50)   NULL,
    [PhoneNumber]                  INT             NOT NULL,
    [PrimaryAttorney]              NVARCHAR (50)   NULL,
    [PrimaryGuardian]              NVARCHAR (50)   NULL,
    [ProofOfService]               BIT             NOT NULL,
    [RealEstateAssets]             INT             NOT NULL,
    [RemainderBeneficiary]         INT             NOT NULL,
    [RemainderBeneficiarySpecific] NVARCHAR (1000) NULL,
    [RequestPowerOfAttorney]       BIT             NOT NULL,
    [ResidentStatus]               BIT             NOT NULL,
    [RetirementAccounts]           INT             NOT NULL,
    [SpecificBequest]              BIT             NOT NULL,
    [StockBonds]                   INT             NOT NULL,
    [TermsAndConditions]           BIT             NOT NULL,
    [TimeStamp]                    DATETIME2 (7)   NOT NULL,
    [UnderAgeChildren]             BIT             NOT NULL,
    [VeteranApplicationUserId1]    NVARCHAR (450)  NULL,
    [VeteranStatus]                BIT             NOT NULL,
    CONSTRAINT [PK_VeteranIntakeForms] PRIMARY KEY CLUSTERED ([VeteranApplicationUserId] ASC),
    CONSTRAINT [FK_VeteranIntakeForms_Veterans_VeteranApplicationUserId1] FOREIGN KEY ([VeteranApplicationUserId1]) REFERENCES [dbo].       [Veterans] ([ApplicationUserId])
```

### Application User Table
```sql
    [Id]                   NVARCHAR (450)     NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [FirstName]            NVARCHAR (MAX)     NULL,
    [LastName]             NVARCHAR (MAX)     NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [MiddleInitial]        NVARCHAR (MAX)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
```

### Veterans Table
```sql
    [ApplicationUserId] NVARCHAR (450) NOT NULL,
    [City]              NVARCHAR (MAX) NULL,
    [State]             NVARCHAR (MAX) NULL,
    [ZIP]               NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Veterans] PRIMARY KEY CLUSTERED ([ApplicationUserId] ASC),
    CONSTRAINT [FK_Veterans_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON       DELETE CASCADE
```

### Lawyers Table
```sql
    [ApplicationUserId] NVARCHAR (450) NOT NULL,
    [BarNumber]         INT            NOT NULL,
    [City]              NVARCHAR (MAX) NULL,
    [Country]           NVARCHAR (MAX) NULL,
    [OtherLanguages]    BIT            NOT NULL,
    [PracticeAreas]     NVARCHAR (MAX) NULL,
    [State]             NVARCHAR (MAX) NULL,
    [YearsOfExperience] INT            NOT NULL,
    [ZipCode]           INT            NOT NULL,
    CONSTRAINT [PK_Lawyers] PRIMARY KEY CLUSTERED ([ApplicationUserId] ASC),
    CONSTRAINT [FK_Lawyers_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON         DELETE CASCADE
```

### Veteran Children
```sql
    [VeteranModelApplicationUserId] NVARCHAR (450) NOT NULL,
    [ChildRelationToVeteran]        INT            NOT NULL,
    [DOB]                           DATETIME2 (7)  NOT NULL,
    [FullName]                      NVARCHAR (50)  NOT NULL,
    [ID]                            INT            NOT NULL,
    [MotherOfChildName]             NVARCHAR (50)  NOT NULL,
    [ParentApplicationUserId]       NVARCHAR (450) NULL,
    CONSTRAINT [PK_VeteranChildren] PRIMARY KEY CLUSTERED ([VeteranModelApplicationUserId] ASC),
    CONSTRAINT [FK_VeteranChildren_Veterans_ParentApplicationUserId] FOREIGN KEY ([ParentApplicationUserId]) REFERENCES [dbo].[Veterans]     ([ApplicationUserId])
```