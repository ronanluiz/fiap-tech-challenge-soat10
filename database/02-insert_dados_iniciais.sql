-- Inserção de dados (exemplos)

INSERT INTO customer (name, email, cpf) VALUES
('João da Silva', 'joao@email.com', '12345678901'),
('Maria Oliveira', 'maria@email.com', '98765432109');

-- Inserção de dados na tabela product
INSERT INTO product (
    name, description, category, price, status, 
    time_to_prepare, note, is_available, quantity_in_stock, 
    created_at, updated_at, user_updated
) VALUES
(
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
INSERT INTO order_item (order_id, product_id, quantity, price) VALUES
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

--------------------------------------------------------------------------------------------------------------------------------
-- Atualização Diogo 08/03/2025 - Inserção de clientes adicionais, assim como pedidos e itens dos pedidos
--------------------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------
-- INSERÇÃO DOS PEDIDOS
------------------------------------------------------------

INSERT INTO customer (customer_id, name, email, cpf)
VALUES
  (3, 'José Neves', 'joseneves@outlook.com', '30806499826'),
  (4, 'Samanta Silva', 'samantas@gmail.com', '16727130809'),
  (5, 'Clarice Porto', 'claricepor@hotmail.com', '58265515855'),
  (6, 'Maria da Silva', 'mariasilva@yahoo.com' ,'06044142850'),
  (7, 'João Oliveira', 'joaoo@hotmail.com', '56156233814'),
  (8, 'Vanessa Souza', 'vanessasouza@gmail.com', '00171203810'),
  (9, 'Silvia dos Santos', 'silviasantos@outlook.com', '05475035806'),
  (10, 'Rodrigo Rodrigues', 'rodrigoro@yahoo.com', '94278522835'),
  (11, 'Marcos Borges', 'marcosborges@gmail.com', '71197537899'),
  (12, 'Helena Cardoso', 'cardosoh@outlook.com', '18581319874'),
  (13, 'Rafaela Ferreira', 'rafaelaferreira@hotmail.com', '75722338800'),
  (14, 'Ana Machado', 'machadoana@outlook.com.br', '93257754841');

------------------------------------------------------------
-- INSERÇÃO DOS PEDIDOS
------------------------------------------------------------
INSERT INTO "order" (order_id, customer_id, status, amount)
VALUES
  (3, 14, 'Ready', 13.50),         
  (4, 13, 'Preparing', 9.00),   
  (5, 12, 'Received', 20.00),         
  (6, 11, 'Finished', 12.50),     
  (7, 10, 'Ready', 15.00),       
  (8, 9, 'Preparing', 11.00),   
  (9, 8, 'Received', 15.00),        
  (10, 7, 'Finished', 18.00),      
  (11, 6, 'Ready', 12.00),          
  (12, 5, 'Preparing', 15.50),    
  (13, 4, 'Preparing', 20.00),
  (14, 3, 'Finished', 12.50);

------------------------------------------------------------
-- INSERÇÃO DOS ITENS DOS PEDIDOS
------------------------------------------------------------
INSERT INTO order_item (order_item_id, order_id, product_id, quantity, price, note)
VALUES
  -- Pedido 3
  (3, 3, 1, 1, 10.00, NULL),
  (4, 3, 3, 1, 3.50, NULL),

  -- Pedido 4
  (5, 4, 2, 1, 5.00, NULL),
  (6, 4, 4, 1, 4.00, NULL),

  -- Pedido 5
  (7, 5, 1, 2, 10.00, NULL),

  -- Pedido 6
  (8, 6, 2, 1, 5.00, NULL),
  (9, 6, 3, 1, 3.50, NULL),
  (10, 6, 4, 1, 4.00, NULL),

  -- Pedido 7
  (11, 7, 1, 1, 10.00, NULL),
  (12, 7, 2, 1, 5.00, NULL),

  -- Pedido 8
  (13, 8, 3, 2, 3.50, NULL),
  (14, 8, 4, 1, 4.00, NULL),

  -- Pedido 9
  (15, 9, 2, 3, 5.00, NULL),

  -- Pedido 10
  (16, 10, 4, 2, 4.00, NULL),
  (17, 10, 1, 1, 10.00, NULL),

  -- Pedido 11
  (18, 11, 3, 2, 3.50, NULL),
  (19, 11, 2, 1, 5.00, NULL),

  -- Pedido 12
  (20, 12, 4, 3, 4.00, NULL),
  (21, 12, 3, 1, 3.50, NULL),

  -- Pedido 13
  (22, 13, 2, 2, 5.00, NULL),
  (23, 13, 1, 1, 10.00, NULL),

  -- Pedido 14
  (24, 14, 3, 1, 3.50, NULL),
  (25, 14, 4, 1, 4.00, NULL),
  (26, 14, 2, 1, 5.00, NULL);


-- Criação da view vw_order_products
CREATE VIEW vw_order_products AS
    SELECT 
        od.order_id, 
        od.status, 
        od.amount,
        string_agg(oi.quantity || ' ' || pr.name, ', ') AS products
    FROM 
        "order" od
    JOIN 
        "order_item" oi ON od.order_id = oi.order_id
    JOIN 
        "product" pr ON oi.product_id = pr.product_id
    WHERE
        od.status <> 'Finished'
    GROUP BY 
        od.order_id, od.status, od.amount
    ORDER BY CASE od.status
        WHEN 'Ready' THEN 1
        WHEN 'Preparing' THEN 2
        WHEN 'Received' THEN 3
        ELSE 4
END;

