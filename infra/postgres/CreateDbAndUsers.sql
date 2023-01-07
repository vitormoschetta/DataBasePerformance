SELECT 'CREATE DATABASE postgres'
    WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'postgres')\gexec
\connect postgres;

-- create schemas
CREATE SCHEMA modeling1;
CREATE SCHEMA modeling2;

-- create users
CREATE USER modeling1 WITH PASSWORD 'modeling1';
CREATE USER modeling2 WITH PASSWORD 'modeling2';

-- grant privileges
GRANT ALL PRIVILEGES ON SCHEMA modeling1 TO modeling1;
GRANT ALL PRIVILEGES ON SCHEMA modeling2 TO modeling2;