-- Inserção de dados (exemplos)

INSERT INTO customer (name, email, cpf) VALUES
('João da Silva', 'joao@email.com', '12345678901'),
('Maria Oliveira', 'maria@email.com', '98765432109');

-- Inserção de dados na tabela product

INSERT INTO product (category, title) VALUES
('Lanche', 'X-Burguer com Queijo e Bacon'),
('Lanche', 'Hot Dog com Salsicha e Purê'),
('Acompanhamento', 'Batata Frita Crocante'),
('Acompanhamento', 'Anéis de Cebola Empanados'),
('Bebida', 'Refrigerante Cola 350ml'),
('Bebida', 'Suco Natural de Laranja'),
('Sobremesa', 'Sorvete de Chocolate com Calda'),
('Sobremesa', 'Mousse de Maracujá Cremoso');

-- Para inserir em "order", precisamos primeiro obter os IDs dos clientes inseridos
-- Usamos subqueries para isso
INSERT INTO "order" (customer_id, amount) VALUES
((SELECT customer_id FROM customer WHERE name = 'João da Silva'), 1999.99),
((SELECT customer_id FROM customer WHERE name = 'Maria Oliveira'), 49.90);

-- Para inserir em order_item, precisamos dos IDs dos produtos e pedidos
INSERT INTO order_item (order_id, product_id, quantity, price) VALUES
(
    (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'João da Silva')),
    (SELECT product_id FROM product WHERE title = 'X-Burguer com Queijo e Bacon'),
    1,
    1999.99
),
(
    (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'Maria Oliveira')),
    (SELECT product_id FROM product WHERE title = 'Batata Frita Crocante'),
    2,
    24.95
);

INSERT INTO payment (payment_id, order_id, amount) VALUES
('PAY001', (SELECT order_id FROM "order" WHERE customer_id = (SELECT customer_id FROM customer WHERE name = 'João da Silva')), 1999.99);