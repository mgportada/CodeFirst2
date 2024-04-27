Maria DB
`docker run --detach --name some-mariadb --env MARIADB_ALLOW_EMPTY_ROOT_PASSWORD=1  mariadb:latest --port 3306:3306`

`mysql -h localhost -u root -p`