# APITEST Fullstack: .NET Core (Backend) + Angular (Frontend)

Repo con dos apps hermanas:

- **Backend (.NET Core)**: `/backend/ApiTestBK`
- **Frontend (Angular)**: `/frontend/ApiFrontEnd`

---

## ✅ Requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download/dotnet)
- [Node.js 18/20+](https://nodejs.org/) (incluye **npm**)
- [Angular CLI](https://angular.io/cli)

## ✅ Estructura
Api-backend-NetCore/
├─ backend/
│  └─ ApiTestBK/              # API .NET Core
└─ frontend/
   └─ ApiFrontEnd/            # App Angular



## ✅ BACKEND

1. Ir a la carpeta del proyecto:
- cd .\backend\ApiTestBK\ApiTestBK o cd ./backend/ApiTestBK/ApiTestBK

2. Restaurar dependencias:
- dotnet restore

3. Ejecutar (puerto opcional)
-dotnet run --urls http://localhost:5000

4. Comprobar que el backend responde:
- Podras ver el http://localhost:5000/swagger

## ✅ FRONTEND
1. Ir a la carpeta del proyecto:
- cd .\frontend\ApiFrontEnd o cd ./frontent/ApiFrontEnd

2. Restaurar dependencias:
- npm i

3. Configurar Ambientes (url backend*)
-./src/environments/environment.ts
./src/environments/environment.development.ts

4. Levantar app:
- ng serve o npm start
Se abrirá en http://localhost:4200 (puerto puede variar)
