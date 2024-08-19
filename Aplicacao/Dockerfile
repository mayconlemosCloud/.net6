# Usando a imagem do SDK do .NET 6 para buildar o projeto
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiando os arquivos .csproj e restaurando as dependências
COPY src/webapi/*.csproj ./webapi/
COPY src/Aplicacao/*.csproj ./Aplicacao/
COPY src/Dominio/*.csproj ./Dominio/
COPY src/Infraestrutura/*.csproj ./Infraestrutura/
RUN dotnet restore ./webapi/webapi.csproj

# Copiando o restante do código e compilando
COPY src/. .
WORKDIR /app/webapi
RUN dotnet publish -c Release -o /out

# Usando uma imagem mais leve para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Copie o script de inicialização para o contêiner
COPY --from=build /app/Infraestrutura/Migrations /app/Infraestrutura/Migrations

# Comando para aplicar as migrações e iniciar a aplicação
ENTRYPOINT ["dotnet", "webapi.dll"]
CMD ["dotnet", "webapi.dll", "migrate"]
