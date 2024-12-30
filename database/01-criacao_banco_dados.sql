CREATE DATABASE IF NOT EXISTS techchallenge;

CREATE TABLE IF NOT EXISTS customer (
    customer_id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NULL,
    cpf VARCHAR(11) NULL
);

CREATE TABLE IF NOT EXISTS product (
    product_id SERIAL PRIMARY KEY,
    category VARCHAR(255) NOT NULL,
    description TEXT NOT NULL
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
    note VARCHAR(255),
    FOREIGN KEY (order_id) REFERENCES "order"(order_id) ON DELETE RESTRICT,
    FOREIGN KEY (product_id) REFERENCES product(product_id) ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS payment (
    payment_id VARCHAR(255) PRIMARY KEY,
    order_id INTEGER NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES "order"(order_id) ON DELETE RESTRICT
);

-- Inserção de dados (exemplos)

INSERT INTO customer (name, email, cpf) VALUES
('João da Silva', 'joao@email.com', '12345678901'),
('Maria Oliveira', 'maria@email.com', '98765432109');

INSERT INTO product (category, description) VALUES
('Eletrônicos', 'Smartphone XYZ'),
('Livros', 'O Senhor dos Anéis');

-- Para inserir em "order", precisamos primeiro obter os IDs dos clientes inseridos
-- Usamos subqueries para isso
INSERT INTO "order" (customer_id, amount) VALUES
((SELECT customer_id FROM customer WHERE name = 'João da Silva'), 1999.99),
((SELECT customer_id FROM customer WHERE name = 'Maria Oliveira'), 49.90);

-- Para inserir em order_item, precisamos dos IDs dos produtos e pedidos
INSERT INTO order_item (order_id, product_id, quantity, price) VALUES
(
    (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'João da Silva')),
    (SELECT product_id FROM product WHERE description = 'Smartphone XYZ'),
    1,
    1999.99
),
(
    (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'Maria Oliveira')),
    (SELECT product_id FROM product WHERE description = 'O Senhor dos Anéis'),
    2,
    24.95
);

INSERT INTO payment (payment_id, order_id, amount) VALUES
('PAY001', (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'João da Silva')), 1999.99);