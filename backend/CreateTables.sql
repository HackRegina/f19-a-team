--
-- PostgreSQL database dump
--

-- Dumped from database version 11.5 (Ubuntu 11.5-3.pgdg16.04+1)
-- Dumped by pg_dump version 12.0

-- Started on 2019-11-02 13:19:59

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
-- TOC entry 3 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: ztcyedrwldzsao
--


--
-- TOC entry 3852 (class 0 OID 0)
-- Dependencies: 3
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: ztcyedrwldzsao
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

--
-- TOC entry 199 (class 1259 OID 2192997)
-- Name: adminusers; Type: TABLE; Schema: public; Owner: ztcyedrwldzsao
--

CREATE TABLE public.adminusers (
    id integer NOT NULL,
    username character varying(64) NOT NULL,
    "Password" character varying(64) NOT NULL,
    "Role" character varying(12)
);

--
-- TOC entry 198 (class 1259 OID 2192995)
-- Name: adminusers_id_seq; Type: SEQUENCE; Schema: public; Owner: ztcyedrwldzsao
--

ALTER TABLE public.adminusers ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.adminusers_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 200 (class 1259 OID 2193517)
-- Name: clientsecret; Type: TABLE; Schema: public; Owner: ztcyedrwldzsao
--

CREATE TABLE public.clientsecret (
    id integer NOT NULL,
    clientsecret character varying(64)
);

--
-- TOC entry 197 (class 1259 OID 2149364)
-- Name: dropofflocation; Type: TABLE; Schema: public; Owner: ztcyedrwldzsao
--

CREATE TABLE public.dropofflocation (
    description character varying(1000),
    isinsidebuilding boolean,
    location_lat double precision,
    location_long double precision
);

--
-- TOC entry 196 (class 1259 OID 2146695)
-- Name: pickuprequest; Type: TABLE; Schema: public; Owner: ztcyedrwldzsao
--

CREATE TABLE public.pickuprequest (
    phone_number character varying(24),
    description character varying(1000),
    count integer,
    status character varying(8),
    location_lat double precision,
    location_long double precision,
    last_modified date,
    id integer NOT NULL
);

--
-- TOC entry 201 (class 1259 OID 2196783)
-- Name: pickuprequest_id_seq; Type: SEQUENCE; Schema: public; Owner: ztcyedrwldzsao
--

CREATE SEQUENCE public.pickuprequest_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

--
-- TOC entry 3855 (class 0 OID 0)
-- Dependencies: 201
-- Name: pickuprequest_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: ztcyedrwldzsao
--

ALTER SEQUENCE public.pickuprequest_id_seq OWNED BY public.pickuprequest.id;


--
-- TOC entry 3717 (class 2604 OID 2196785)
-- Name: pickuprequest id; Type: DEFAULT; Schema: public; Owner: ztcyedrwldzsao
--

ALTER TABLE ONLY public.pickuprequest ALTER COLUMN id SET DEFAULT nextval('public.pickuprequest_id_seq'::regclass);


--
-- TOC entry 3844 (class 0 OID 2192997)
-- Dependencies: 199
-- Data for Name: adminusers; Type: TABLE DATA; Schema: public; Owner: ztcyedrwldzsao
--

INSERT INTO public.adminusers OVERRIDING SYSTEM VALUE VALUES (1, 'apss', '2c26b46b68ffc68ff99b453c1d30413413422d706483bfa0f98a5e886266e7ae', 'Admin');


--
-- TOC entry 3845 (class 0 OID 2193517)
-- Dependencies: 200
-- Data for Name: clientsecret; Type: TABLE DATA; Schema: public; Owner: ztcyedrwldzsao
--

INSERT INTO public.clientsecret VALUES (0, 'TheMostSecureClientSecretInTheWorld');


--
-- TOC entry 3856 (class 0 OID 0)
-- Dependencies: 198
-- Name: adminusers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: ztcyedrwldzsao
--

SELECT pg_catalog.setval('public.adminusers_id_seq', 1, true);


--
-- TOC entry 3857 (class 0 OID 0)
-- Dependencies: 201
-- Name: pickuprequest_id_seq; Type: SEQUENCE SET; Schema: public; Owner: ztcyedrwldzsao
--

SELECT pg_catalog.setval('public.pickuprequest_id_seq', 7, true);


--
-- TOC entry 3719 (class 2606 OID 2196794)
-- Name: pickuprequest pickuprequest_pk; Type: CONSTRAINT; Schema: public; Owner: ztcyedrwldzsao
--

ALTER TABLE ONLY public.pickuprequest
    ADD CONSTRAINT pickuprequest_pk PRIMARY KEY (id);

-- Completed on 2019-11-02 13:20:06

--
-- PostgreSQL database dump complete
--
