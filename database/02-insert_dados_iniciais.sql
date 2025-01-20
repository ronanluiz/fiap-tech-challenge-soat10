-- Inserção de dados (exemplos)

INSERT INTO customer (name, email, cpf) VALUES
('João da Silva', 'joao@email.com', '12345678901'),
('Maria Oliveira', 'maria@email.com', '98765432109');

-- Inserção de dados na tabela product
INSERT INTO product (
    product_id, name, description, category, price, status, 
    time_to_prepare, note, is_available, quantity_in_stock, 
    created_at, updated_at, user_updated
) VALUES
(
    '1',
    'X-Burguer com Queijo e Bacon',
    'Três hamburgueres, alface, queijo, molho espacial, cebola, pickles e pão com gergelin',
    0, -- Lanche (assumindo que "Lanche" seja representado como 0 no enum)
    10.00,
    1, -- Status 1 (provavelmente representa um valor válido no enum de status)
    10, -- 10 minutos de preparo, convertido para valor inteiro
    NULL,
    FALSE,
    10,
    '2025-01-15T13:25:37.6893259Z',
    '2025-01-15T13:25:37.689327Z',
    'João da Silva'
),
(
    '2',
    'Batata Frita Crocante',
    'Porção de batatas fritas crocantes, ideal para acompanhar qualquer lanche',
    1, -- Acompanhamento (assumindo que "Acompanhamento" seja representado como 1 no enum)
    5.00,
    1,
    5,
    NULL,
    TRUE,
    20,
    '2025-01-15T14:00:00Z',
    '2025-01-15T14:00:00Z',
    'João da Silva'
),
(
    '3',
    'Refrigerante Cola 350ml',
    'Lata de refrigerante sabor cola, gelado e refrescante',
    2, -- Bebida (assumindo que "Bebida" seja representado como 2 no enum)
    3.50,
    1,
    0,
    NULL,
    TRUE,
    50,
    '2025-01-15T14:15:00Z',
    '2025-01-15T14:15:00Z',
    'João da Silva'
),
(
    '4',
    'Mousse de Maracujá Cremoso',
    'Sobremesa cremosa feita com maracujá fresco, ideal para adoçar o dia',
    3, -- Sobremesa (assumindo que "Sobremesa" seja representado como 3 no enum)
    4.00,
    1,
    3,
    NULL,
    TRUE,
    15,
    '2025-01-15T14:30:00Z',
    '2025-01-15T14:30:00Z',
    'Maria Oliveira'
);

-- Para inserir em "order", precisamos primeiro obter os IDs dos clientes inseridos
-- Usamos subqueries para isso
INSERT INTO "order" (customer_id, amount) VALUES
((SELECT customer_id FROM customer WHERE name = 'João da Silva'), 1999.99),
((SELECT customer_id FROM customer WHERE name = 'Maria Oliveira'), 49.90);

-- Para inserir em order_item, precisamos dos IDs dos produtos e pedidos
INSERT INTO order_item (order_id, product_id, quantity, price, note) VALUES
(
    (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'João da Silva')),
    (SELECT product_id FROM product WHERE name = 'X-Burguer com Queijo e Bacon'),
    1,
    1999.99
),
(
    (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'Maria Oliveira')),
    (SELECT product_id FROM product WHERE name = 'Batata Frita Crocante'),
    2,
    24.95
);

INSERT INTO payment (payment_id, order_id, amount) VALUES
('PAY001', (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'João da Silva')), 1999.99);