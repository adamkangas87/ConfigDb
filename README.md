#Migrations:
```
add-migration {MIGRATION_NAME_HERE} -context DataContext -o Migrations -StartupProject WebUi
update-database -context DataContext
```