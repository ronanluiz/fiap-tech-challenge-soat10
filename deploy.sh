#!/bin/bash

# Criando secrets
kubectl create secret generic postgres-secret --from-literal=POSTGRES_USER=fiap_user --from-literal=POSTGRES_PASSWORD=fiap_password
kubectl create secret generic app-secret --from-literal=DbConnection__User=fiap_user --from-literal=DbConnection__Password=fiap_password --from-literal=PaymentService__Token=APP_USR-3827549426311414-031406-158f43d497651f357ee417d643de1caf-2309279098

# Criar o ConfigMap com os scripts SQL
kubectl create configmap postgres-init-scripts --from-file=01-criacao_banco_dados.sql=database/01-criacao_banco_dados.sql --from-file=02-insert_dados_iniciais.sql=database/02-insert_dados_iniciais.sql

# Aplicar o PVC para o Postgres
kubectl apply -f postgres-pvc.yaml

# Aplicar o Deployment e Service do Postgres
kubectl apply -f postgres-deployment.yaml
kubectl apply -f postgres-service.yaml
kubectl apply -f postgres-configmap.yaml

# Aplicar o Deployment e Service da aplicação
kubectl apply -f api-service.yaml
kubectl apply -f api-deployment.yaml
kubectl apply -f api-hpa.yaml
kubectl apply -f webhook-service.yaml
kubectl apply -f webhook-deployment.yaml
kubectl apply -f webhook-hpa.yaml
kubectl apply -f mock-service.yaml
kubectl apply -f mock-deployment.yaml
