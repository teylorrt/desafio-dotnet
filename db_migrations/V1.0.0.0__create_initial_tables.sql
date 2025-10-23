
-- Transaction Type Table
CREATE TABLE IF NOT EXISTS public.transaction_type
(
    id smallint NOT NULL,
    "description" varchar(25) COLLATE pg_catalog."default" NOT NULL,
    nature varchar(1) NOT NULL CHECK (nature IN ('I', 'E')),
    sign varchar(1) NOT NULL CHECK (sign IN ('+', '-')),
    CONSTRAINT transaction_type_pkey PRIMARY KEY (id),
    CONSTRAINT CK_nature_sign CHECK ((nature = 'I' AND sign = '+') OR (nature = 'E' AND sign = '-'))
);

INSERT INTO public.transaction_type (id, description, nature, sign) VALUES 
  (1, 'Debit', 'I', '+'),
  (2, 'Boleto', 'E', '-'),
  (3, 'Financing', 'E', '-'),
  (4, 'Credit', 'I', '+'),
  (5, 'Loan Receipt', 'I', '+'),
  (6, 'Sales', 'I', '+'),
  (7, 'TED Receipt', 'I', '+'),
  (8, 'DOC Receipt', 'I', '+'),
  (9, 'Rent', 'E', '-');

-- Operation Table
CREATE TABLE IF NOT EXISTS public.operation
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    "type" smallint NOT NULL,
    "time" timestamp with time zone NOT NULL,
    "value" numeric(10,2) NOT NULL,
    cpf varchar(11) NOT NULL,
    "card" varchar(12) NOT NULL,
    store_owner varchar(14) NOT NULL,
    store_name varchar(19) NOT NULL,
    CONSTRAINT operation_pkey PRIMARY KEY (id),
    CONSTRAINT "fk_operation.type" FOREIGN KEY (type)
        REFERENCES public.transaction_type (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);