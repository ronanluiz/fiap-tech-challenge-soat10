CREATE TABLE IF NOT EXISTS customer (
    customer_id SERIAL PRIMARY KEY,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    cpf VARCHAR(11) UNIQUE,
    status VARCHAR(50) DEFAULT 'active'
);

CREATE TABLE IF NOT EXISTS product (
    product_id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(200) NOT NULL,
    category INT NOT NULL, 
    price NUMERIC(10, 2) NOT NULL,
    status INT NOT NULL, 
    time_to_prepare NUMERIC(5, 2) NOT NULL, -- Tempo em minutos como decimal
    note VARCHAR(255), -- Nota é opcional
    is_available BOOLEAN NOT NULL,
    created_at TIMESTAMP NOT NULL,
    updated_at TIMESTAMP NOT NULL,
    user_updated VARCHAR(100),
    quantity_in_stock INT NOT NULL
);

CREATE TABLE IF NOT EXISTS "order" (
    order_id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL,
    status VARCHAR(255) NOT NULL DEFAULT 'Requested',
    amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id) ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS order_item (
    order_item_id SERIAL PRIMARY KEY,
    order_id INTEGER NOT NULL,
    product_id INTEGER NOT NULL,
    quantity INTEGER NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    note VARCHAR(255) NULL,
    FOREIGN KEY (order_id) REFERENCES "order"(order_id) ON DELETE RESTRICT,
    FOREIGN KEY (product_id) REFERENCES product(product_id) ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS payment (
    payment_id VARCHAR(255) PRIMARY KEY,
    order_id INTEGER NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES "order"(order_id) ON DELETE RESTRICT
);