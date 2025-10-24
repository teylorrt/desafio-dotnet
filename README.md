# ByCoders Programming Challenge

## This Challenge was implemented using the following technologies:
- .NET 9
- ASP.NET Core Web API
- React TS + Vite
- Dapper
- PostgreSQL
- Docker
- Flyway for migrations
- Shell script

## Requirements
- Ubuntu 24.04
- Docker

## How to Setup and Test
#### All the following commands must be run in the project root folder

### Step 1: Install Docker
```bash
sudo sh get-docker.sh
```

### Step 2: Start containers
- The first time this will take a while as it is necessary to create the images.
```bash
docker compose u -d
```
- If everything goes well the result should be like this
<img width="1167" height="180" alt="image" src="https://github.com/user-attachments/assets/b20c6772-f34a-4c1e-b046-ee46c6ea0dc0" />

### Step 3: Access import/list page to test
Access url http://localhost:5173/

### Step 4: To stop containers:
```bash
docker stop $(docker ps -a -q)
```

