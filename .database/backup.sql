--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3 (Debian 16.3-1.pgdg120+1)
-- Dumped by pg_dump version 16.3 (Debian 16.3-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: core; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA core;


ALTER SCHEMA core OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: accounts; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.accounts (
    id integer NOT NULL,
    user_id integer,
    name character varying(64) NOT NULL,
    amount numeric(12,6) NOT NULL,
    currency character varying(16),
    active boolean DEFAULT true NOT NULL,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.accounts OWNER TO postgres;

--
-- Name: accounts_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.accounts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.accounts_id_seq OWNER TO postgres;

--
-- Name: accounts_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.accounts_id_seq OWNED BY core.accounts.id;


--
-- Name: bank_accounts; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.bank_accounts (
    account_id integer,
    bank_id integer,
    iban character varying(64) NOT NULL
);


ALTER TABLE core.bank_accounts OWNER TO postgres;

--
-- Name: banks; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.banks (
    id integer NOT NULL,
    name character varying(64) NOT NULL,
    active boolean DEFAULT true NOT NULL,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.banks OWNER TO postgres;

--
-- Name: banks_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.banks_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.banks_id_seq OWNER TO postgres;

--
-- Name: banks_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.banks_id_seq OWNED BY core.banks.id;


--
-- Name: cash_accounts; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.cash_accounts (
    account_id integer
);


ALTER TABLE core.cash_accounts OWNER TO postgres;

--
-- Name: currencies; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.currencies (
    code character varying(16) NOT NULL,
    name character varying(64) NOT NULL,
    active boolean DEFAULT true NOT NULL,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.currencies OWNER TO postgres;

--
-- Name: deposits; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.deposits (
    id integer NOT NULL,
    account_id integer,
    amount numeric(12,6) NOT NULL,
    currency character varying(16),
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.deposits OWNER TO postgres;

--
-- Name: deposits_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.deposits_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.deposits_id_seq OWNER TO postgres;

--
-- Name: deposits_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.deposits_id_seq OWNED BY core.deposits.id;


--
-- Name: goals; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.goals (
    id integer NOT NULL,
    user_id integer,
    name character varying(64) NOT NULL,
    description character varying(128),
    amount numeric(12,6) NOT NULL,
    currency character varying(16),
    start_date date,
    end_date date,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.goals OWNER TO postgres;

--
-- Name: goals_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.goals_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.goals_id_seq OWNER TO postgres;

--
-- Name: goals_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.goals_id_seq OWNED BY core.goals.id;


--
-- Name: subscriptions; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.subscriptions (
    id integer NOT NULL,
    user_id integer,
    name character varying(64) NOT NULL,
    description character varying(128),
    amount numeric(12,6) NOT NULL,
    currency character varying(16),
    active boolean DEFAULT true NOT NULL,
    payment_date date,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.subscriptions OWNER TO postgres;

--
-- Name: subscriptions_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.subscriptions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.subscriptions_id_seq OWNER TO postgres;

--
-- Name: subscriptions_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.subscriptions_id_seq OWNED BY core.subscriptions.id;


--
-- Name: transfers; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.transfers (
    id integer NOT NULL,
    from_account_id integer,
    to_account_id integer,
    source_amount numeric(12,6) NOT NULL,
    target_amount numeric(12,6) NOT NULL,
    conversion_rate numeric(12,6) NOT NULL,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.transfers OWNER TO postgres;

--
-- Name: transfers_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.transfers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.transfers_id_seq OWNER TO postgres;

--
-- Name: transfers_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.transfers_id_seq OWNED BY core.transfers.id;


--
-- Name: users; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.users (
    id integer NOT NULL,
    username character varying(64) NOT NULL,
    email character varying(256) NOT NULL,
    password character varying(256) NOT NULL,
    active boolean DEFAULT true NOT NULL,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.users OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.users_id_seq OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.users_id_seq OWNED BY core.users.id;


--
-- Name: withdrawals; Type: TABLE; Schema: core; Owner: postgres
--

CREATE TABLE core.withdrawals (
    id integer NOT NULL,
    account_id integer,
    amount numeric(12,6) NOT NULL,
    currency character varying(16),
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone DEFAULT now()
);


ALTER TABLE core.withdrawals OWNER TO postgres;

--
-- Name: withdrawals_id_seq; Type: SEQUENCE; Schema: core; Owner: postgres
--

CREATE SEQUENCE core.withdrawals_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE core.withdrawals_id_seq OWNER TO postgres;

--
-- Name: withdrawals_id_seq; Type: SEQUENCE OWNED BY; Schema: core; Owner: postgres
--

ALTER SEQUENCE core.withdrawals_id_seq OWNED BY core.withdrawals.id;


--
-- Name: accounts id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.accounts ALTER COLUMN id SET DEFAULT nextval('core.accounts_id_seq'::regclass);


--
-- Name: banks id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.banks ALTER COLUMN id SET DEFAULT nextval('core.banks_id_seq'::regclass);


--
-- Name: deposits id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.deposits ALTER COLUMN id SET DEFAULT nextval('core.deposits_id_seq'::regclass);


--
-- Name: goals id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.goals ALTER COLUMN id SET DEFAULT nextval('core.goals_id_seq'::regclass);


--
-- Name: subscriptions id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.subscriptions ALTER COLUMN id SET DEFAULT nextval('core.subscriptions_id_seq'::regclass);


--
-- Name: transfers id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.transfers ALTER COLUMN id SET DEFAULT nextval('core.transfers_id_seq'::regclass);


--
-- Name: users id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.users ALTER COLUMN id SET DEFAULT nextval('core.users_id_seq'::regclass);


--
-- Name: withdrawals id; Type: DEFAULT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.withdrawals ALTER COLUMN id SET DEFAULT nextval('core.withdrawals_id_seq'::regclass);


--
-- Data for Name: accounts; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.accounts (id, user_id, name, amount, currency, active, created_at, updated_at) FROM stdin;
\.


--
-- Data for Name: bank_accounts; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.bank_accounts (account_id, bank_id, iban) FROM stdin;
\.


--
-- Data for Name: banks; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.banks (id, name, active, created_at, updated_at) FROM stdin;
1	Bank of America	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
2	Chase Bank	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
3	Wells Fargo	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
4	Citibank	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
5	HSBC	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
6	Barclays	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
7	Deutsche Bank	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
8	BNP Paribas	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
9	Santander	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
10	UBS	t	2024-07-24 09:43:49.76635+00	2024-07-24 09:43:49.76635+00
\.


--
-- Data for Name: cash_accounts; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.cash_accounts (account_id) FROM stdin;
\.


--
-- Data for Name: currencies; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.currencies (code, name, active, created_at, updated_at) FROM stdin;
USD	US Dollar	t	2024-07-24 09:43:49.770379+00	2024-07-24 09:43:49.770379+00
EUR	Euro	t	2024-07-24 09:43:49.770379+00	2024-07-24 09:43:49.770379+00
JPY	Japanese Yen	t	2024-07-24 09:43:49.770379+00	2024-07-24 09:43:49.770379+00
GBP	British Pound	t	2024-07-24 09:43:49.770379+00	2024-07-24 09:43:49.770379+00
AUD	Australian Dollar	t	2024-07-24 09:43:49.770379+00	2024-07-24 09:43:49.770379+00
\.


--
-- Data for Name: deposits; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.deposits (id, account_id, amount, currency, created_at, updated_at) FROM stdin;
\.


--
-- Data for Name: goals; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.goals (id, user_id, name, description, amount, currency, start_date, end_date, created_at, updated_at) FROM stdin;
6	1	Vacation	Save for vacation	1000.000000	USD	2024-01-01	2024-12-31	2024-07-24 09:48:59.761848+00	2024-07-24 09:48:59.761848+00
7	2	New Car	Save for a new car	5000.000000	EUR	2024-01-01	2024-12-31	2024-07-24 09:48:59.761848+00	2024-07-24 09:48:59.761848+00
8	3	Laptop	Save for a new laptop	2000.000000	JPY	2024-01-01	2024-12-31	2024-07-24 09:48:59.761848+00	2024-07-24 09:48:59.761848+00
9	4	House Down Payment	Save for a house down payment	10000.000000	GBP	2024-01-01	2024-12-31	2024-07-24 09:48:59.761848+00	2024-07-24 09:48:59.761848+00
10	5	Emergency Fund	Build an emergency fund	3000.000000	AUD	2024-01-01	2024-12-31	2024-07-24 09:48:59.761848+00	2024-07-24 09:48:59.761848+00
\.


--
-- Data for Name: subscriptions; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.subscriptions (id, user_id, name, description, amount, currency, active, payment_date, created_at, updated_at) FROM stdin;
6	1	Netflix	Monthly subscription	15.000000	USD	t	2024-01-01	2024-07-24 09:48:42.089799+00	2024-07-24 09:48:42.089799+00
7	2	Spotify	Monthly subscription	10.000000	EUR	t	2024-01-01	2024-07-24 09:48:42.089799+00	2024-07-24 09:48:42.089799+00
8	3	Amazon Prime	Monthly subscription	12.000000	JPY	t	2024-01-01	2024-07-24 09:48:42.089799+00	2024-07-24 09:48:42.089799+00
9	4	Hulu	Monthly subscription	8.000000	GBP	t	2024-01-01	2024-07-24 09:48:42.089799+00	2024-07-24 09:48:42.089799+00
10	5	Disney+	Monthly subscription	9.000000	AUD	t	2024-01-01	2024-07-24 09:48:42.089799+00	2024-07-24 09:48:42.089799+00
\.


--
-- Data for Name: transfers; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.transfers (id, from_account_id, to_account_id, source_amount, target_amount, conversion_rate, created_at, updated_at) FROM stdin;
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.users (id, username, email, password, active, created_at, updated_at) FROM stdin;
1	john_doe	john.doe@example.com	password1	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
2	jane_smith	jane.smith@example.com	password2	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
3	michael_brown	michael.brown@example.com	password3	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
4	emily_davis	emily.davis@example.com	password4	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
5	william_jones	william.jones@example.com	password5	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
6	olivia_martinez	olivia.martinez@example.com	password6	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
7	james_garcia	james.garcia@example.com	password7	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
8	sophia_rodriguez	sophia.rodriguez@example.com	password8	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
9	benjamin_lee	benjamin.lee@example.com	password9	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
10	ava_wilson	ava.wilson@example.com	password10	t	2024-07-24 09:45:17.147504+00	2024-07-24 09:45:17.147504+00
\.


--
-- Data for Name: withdrawals; Type: TABLE DATA; Schema: core; Owner: postgres
--

COPY core.withdrawals (id, account_id, amount, currency, created_at, updated_at) FROM stdin;
\.


--
-- Name: accounts_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.accounts_id_seq', 24, true);


--
-- Name: banks_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.banks_id_seq', 11, true);


--
-- Name: deposits_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.deposits_id_seq', 10, true);


--
-- Name: goals_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.goals_id_seq', 10, true);


--
-- Name: subscriptions_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.subscriptions_id_seq', 10, true);


--
-- Name: transfers_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.transfers_id_seq', 1, false);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.users_id_seq', 10, true);


--
-- Name: withdrawals_id_seq; Type: SEQUENCE SET; Schema: core; Owner: postgres
--

SELECT pg_catalog.setval('core.withdrawals_id_seq', 10, true);


--
-- Name: accounts accounts_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.accounts
    ADD CONSTRAINT accounts_pkey PRIMARY KEY (id);


--
-- Name: bank_accounts bank_accounts_iban_key; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.bank_accounts
    ADD CONSTRAINT bank_accounts_iban_key UNIQUE (iban);


--
-- Name: banks banks_name_key; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.banks
    ADD CONSTRAINT banks_name_key UNIQUE (name);


--
-- Name: banks banks_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.banks
    ADD CONSTRAINT banks_pkey PRIMARY KEY (id);


--
-- Name: currencies currencies_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.currencies
    ADD CONSTRAINT currencies_pkey PRIMARY KEY (code);


--
-- Name: deposits deposits_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.deposits
    ADD CONSTRAINT deposits_pkey PRIMARY KEY (id);


--
-- Name: goals goals_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.goals
    ADD CONSTRAINT goals_pkey PRIMARY KEY (id);


--
-- Name: subscriptions subscriptions_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.subscriptions
    ADD CONSTRAINT subscriptions_pkey PRIMARY KEY (id);


--
-- Name: transfers transfers_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.transfers
    ADD CONSTRAINT transfers_pkey PRIMARY KEY (id);


--
-- Name: users users_email_key; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.users
    ADD CONSTRAINT users_email_key UNIQUE (email);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- Name: users users_username_key; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.users
    ADD CONSTRAINT users_username_key UNIQUE (username);


--
-- Name: withdrawals withdrawals_pkey; Type: CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.withdrawals
    ADD CONSTRAINT withdrawals_pkey PRIMARY KEY (id);


--
-- Name: accounts accounts_currency_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.accounts
    ADD CONSTRAINT accounts_currency_fkey FOREIGN KEY (currency) REFERENCES core.currencies(code);


--
-- Name: accounts accounts_user_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.accounts
    ADD CONSTRAINT accounts_user_id_fkey FOREIGN KEY (user_id) REFERENCES core.users(id) ON DELETE CASCADE;


--
-- Name: bank_accounts bank_accounts_account_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.bank_accounts
    ADD CONSTRAINT bank_accounts_account_id_fkey FOREIGN KEY (account_id) REFERENCES core.accounts(id) ON DELETE CASCADE;


--
-- Name: bank_accounts bank_accounts_bank_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.bank_accounts
    ADD CONSTRAINT bank_accounts_bank_id_fkey FOREIGN KEY (bank_id) REFERENCES core.banks(id) ON DELETE CASCADE;


--
-- Name: cash_accounts cash_accounts_account_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.cash_accounts
    ADD CONSTRAINT cash_accounts_account_id_fkey FOREIGN KEY (account_id) REFERENCES core.accounts(id) ON DELETE CASCADE;


--
-- Name: deposits deposits_account_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.deposits
    ADD CONSTRAINT deposits_account_id_fkey FOREIGN KEY (account_id) REFERENCES core.accounts(id) ON DELETE CASCADE;


--
-- Name: deposits deposits_currency_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.deposits
    ADD CONSTRAINT deposits_currency_fkey FOREIGN KEY (currency) REFERENCES core.currencies(code);


--
-- Name: goals goals_currency_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.goals
    ADD CONSTRAINT goals_currency_fkey FOREIGN KEY (currency) REFERENCES core.currencies(code);


--
-- Name: goals goals_user_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.goals
    ADD CONSTRAINT goals_user_id_fkey FOREIGN KEY (user_id) REFERENCES core.users(id) ON DELETE CASCADE;


--
-- Name: subscriptions subscriptions_currency_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.subscriptions
    ADD CONSTRAINT subscriptions_currency_fkey FOREIGN KEY (currency) REFERENCES core.currencies(code);


--
-- Name: subscriptions subscriptions_user_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.subscriptions
    ADD CONSTRAINT subscriptions_user_id_fkey FOREIGN KEY (user_id) REFERENCES core.users(id) ON DELETE CASCADE;


--
-- Name: transfers transfers_from_account_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.transfers
    ADD CONSTRAINT transfers_from_account_id_fkey FOREIGN KEY (from_account_id) REFERENCES core.accounts(id) ON DELETE CASCADE;


--
-- Name: transfers transfers_to_account_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.transfers
    ADD CONSTRAINT transfers_to_account_id_fkey FOREIGN KEY (to_account_id) REFERENCES core.accounts(id) ON DELETE CASCADE;


--
-- Name: withdrawals withdrawals_account_id_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.withdrawals
    ADD CONSTRAINT withdrawals_account_id_fkey FOREIGN KEY (account_id) REFERENCES core.accounts(id) ON DELETE CASCADE;


--
-- Name: withdrawals withdrawals_currency_fkey; Type: FK CONSTRAINT; Schema: core; Owner: postgres
--

ALTER TABLE ONLY core.withdrawals
    ADD CONSTRAINT withdrawals_currency_fkey FOREIGN KEY (currency) REFERENCES core.currencies(code);


--
-- PostgreSQL database dump complete
--

