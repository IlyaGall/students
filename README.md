# Разварачивание сервера

Развернуть его с помощью докер или создать сервер(я сделал с помощью докера)

## а Нужно установить docker desctop

!В интернете полно инструкций как это делать, главное проверь, что просле устаноки у тебя виртуализация включена

![img](https://github.com/IlyaGall/students/blob/main/img/4.JPG)

Запусти его: 

У меня выглядит так, так как у меня n количество контенеров

![img](https://github.com/IlyaGall/students/blob/main/img/1.JPG)

он должен быть запущен, при создании контейнеров

Затем открыть powerShell от админимстратора


тут 2 варианат: 

* 1 создатье образ сервера с помощью файла doceker-compose
* 2 просто вбить команду в powershell

### 1 вариант 

перейти в директрую, где лежит файл с помощью команды ```cd -path путь```, например ```cd -path C:\Users\Ilya\Desktop\SQL_server```, а затем вызвать команду ```docker-compose up -d``` - файл режит в репозитории под названием ```docker-compose.yml```

![img](https://github.com/IlyaGall/students/blob/main/img/2.JPG)

!во время выполнения команды ```docker-compose up -d``` у тебя может отличатся интерфейс и могут быть немого другие команды, так как ты это делаешь первый раз

в докере появится такой контейнер

![img](https://github.com/IlyaGall/students/blob/main/img/3.JPG)

## 2 вариант просто вбить команду 

```docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd"-p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server:2022-latest``` 

название контенера будет отличатся от первого варианта но суть такая же


### открытие приложение windows form

лежит в репозитирии



