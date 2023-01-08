SELECT 'CREATE DATABASE modeling1'
    WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'modeling1')\gexec
\connect modeling1;

-- create schemas
CREATE SCHEMA modeling1;

-- create users
CREATE USER modeling1 WITH PASSWORD 'modeling1';

-- grant privileges
GRANT ALL PRIVILEGES ON SCHEMA modeling1 TO modeling1;


SELECT 'CREATE DATABASE modeling2'
    WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'modeling2')\gexec
\connect modeling2;

-- create schemas
CREATE SCHEMA modeling2;

-- create users
CREATE USER modeling2 WITH PASSWORD 'modeling2';

-- grant privileges
GRANT ALL PRIVILEGES ON SCHEMA modeling2 TO modeling2;