CREATE TABLE "Banks" (
    "Id" uuid NOT NULL,
    "Name" character varying(64) NOT NULL,
    "IsActive" boolean NOT NULL DEFAULT FALSE,
    "CreateDate" timestamp with time zone NOT NULL,
    "UpdateDate" timestamp with time zone NULL,
    CONSTRAINT "PK_Banks" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_Banks_Name" UNIQUE ("Name")
);


CREATE TABLE "Currencies" (
    "Id" uuid NOT NULL,
    "Name" character varying(64) NOT NULL,
    "Code" character varying(8) NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "UpdateDate" timestamp with time zone NULL,
    CONSTRAINT "PK_Currencies" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_Currencies_Code" UNIQUE ("Code"),
    CONSTRAINT "AK_Currencies_Name" UNIQUE ("Name")
);


CREATE TABLE "UserIncomes" (
    "Id" uuid NOT NULL,
    "Amount" numeric NOT NULL,
    "Source" integer NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "UpdateDate" timestamp with time zone NULL,
    CONSTRAINT "PK_UserIncomes" PRIMARY KEY ("Id")
);


CREATE TABLE "Users" (
    "Id" uuid NOT NULL,
    "Email" character varying(256) NOT NULL,
    "PasswordHash" text NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "UpdateDate" timestamp with time zone NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_Users_Email" UNIQUE ("Email")
);


CREATE TABLE "UserCategories" (
    "Id" uuid NOT NULL,
    "Name" character varying(64) NOT NULL,
    "Description" character varying(256) NULL,
    "UserId" uuid NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "UpdateDate" timestamp with time zone NULL,
    CONSTRAINT "PK_UserCategories" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_UserCategories_UserId_Name" UNIQUE ("UserId", "Name"),
    CONSTRAINT "FK_UserCategories_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);


CREATE TABLE "BankAccounts" (
    "Id" uuid NOT NULL,
    "Iban" character varying(64) NOT NULL,
    "Amount" numeric NOT NULL,
    "BankId" uuid NOT NULL,
    "CurrencyId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "CategoryId" uuid NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "UpdateDate" timestamp with time zone NULL,
    CONSTRAINT "PK_BankAccounts" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_BankAccounts_Iban" UNIQUE ("Iban"),
    CONSTRAINT "FK_BankAccounts_Banks_BankId" FOREIGN KEY ("BankId") REFERENCES "Banks" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_BankAccounts_Currencies_CurrencyId" FOREIGN KEY ("CurrencyId") REFERENCES "Currencies" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_BankAccounts_UserCategories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "UserCategories" ("Id") ON DELETE SET NULL,
    CONSTRAINT "FK_BankAccounts_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);


CREATE TABLE "CashAccounts" (
    "Id" uuid NOT NULL,
    "Name" character varying(64) NOT NULL,
    "Amount" numeric NOT NULL,
    "CurrencyId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "CategoryId" uuid NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "UpdateDate" timestamp with time zone NULL,
    CONSTRAINT "PK_CashAccounts" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_CashAccounts_Currencies_CurrencyId" FOREIGN KEY ("CurrencyId") REFERENCES "Currencies" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_CashAccounts_UserCategories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "UserCategories" ("Id") ON DELETE SET NULL,
    CONSTRAINT "FK_CashAccounts_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);


CREATE INDEX "IX_BankAccounts_BankId" ON "BankAccounts" ("BankId");


CREATE INDEX "IX_BankAccounts_CategoryId" ON "BankAccounts" ("CategoryId");


CREATE INDEX "IX_BankAccounts_CurrencyId" ON "BankAccounts" ("CurrencyId");


CREATE INDEX "IX_BankAccounts_UserId" ON "BankAccounts" ("UserId");


CREATE INDEX "IX_CashAccounts_CategoryId" ON "CashAccounts" ("CategoryId");


CREATE INDEX "IX_CashAccounts_CurrencyId" ON "CashAccounts" ("CurrencyId");


CREATE INDEX "IX_CashAccounts_UserId" ON "CashAccounts" ("UserId");


