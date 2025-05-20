create table dbo.CoreItemLogs
(
    Id int not null identity(1, 1),
    CreatedAt datetime not null default(getutcdate()),
    UpdatedAt datetime null,
    Uuid varchar(60) null,
    TransactionType varchar(255) null,
    Amount int null,
    MerchantAccountId int null,
    BatchId int null,
    ItemNumber int null,
    Voided tinyint null default(0),
    SerializedRequest varchar(max) null,
    StatusName varchar(255) null,
    CoreVersion varchar(10) null,
    Processor varchar(50) null,
    ResponseTime decimal(9, 4) null,
    Response varchar(max) null,
    ResponseCode varchar(10) null,
    Envelope varchar(max) null,
    OfflineFlag tinyint null default(0),
    constraint pk_CoreItemLogs primary key nonclustered (Id),
    constraint ucl_CoreItemLogs unique clustered (Uuid)
);
