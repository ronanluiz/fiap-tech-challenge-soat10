#!/bin/bash

# Criar o ConfigMap com os scripts SQL
kubectl create configmap postgres-init-scripts \
  --from-file=01-criacao_banco_dados.sql=database/01-criacao_banco_dados.sql \
  --from-file=02-insert_dados_iniciais.sql=database/02-insert_dados_iniciais.sql

# Aplicar o PVC para o Postgres
kubectl apply -f postgres-pvc.yaml

# Aplicar o Deployment e Service do Postgres
kubectl apply -f postgres-deployment.yaml
kubectl apply -f postgres-service.yaml

# Aplicar o Deployment e Service da aplicação
kubectl apply -f app-service.yaml
kubectl apply -f app-deployment.yaml

# Aplicar o pod, caso necessário
kubectl apply -f pod.yaml
