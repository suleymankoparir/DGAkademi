W-01
Migration is done in the Repository layer.
| Url  | Type |
| ------------- | ------------- |
| https://dkakademi-w-01.herokuapp.com/api/user  | HTTP POST  |
| https://dkakademi-w-01.herokuapp.com/api/user/signup  | HTTP POST  |


Json format
{
    "username":"suleymankoparir",
    "password":"password"
}

Endpoints below require jwt token
| Url  | Type |
| ------------- | ------------- |
| https://dkakademi-w-01.herokuapp.com/api/car  | HTTP GET  |
| https://dkakademi-w-01.herokuapp.com/api/car/getbmw   | HTTP GET  |
| https://dkakademi-w-01.herokuapp.com/api/car/getaudi  | HTTP GET |
|https://dkakademi-w-01.herokuapp.com/api/car/getmercedes | HTTP GET |


W02
Migration is done in the Repository layer.
| Url | Type | Jwt | Access Role
| ------------- | ------------- | ------------- | ------------- |
|api/person|HTTP POST|No|Everyone|
|api/person/signup|HTTP POST|No|Everyone|
|api/person|HTTP GET|Yes|Manager, Human Resourses|
|api/person/{id}|HTTP GET|Yes|Manager, Human Resourses|
|api/person|HTTP PUT|Yes|Manager, Human Resourses|
|api/person/{id}|HTTP DELETE|Yes|Manager, Human Resourses|
|api/department|HTTP GET|No|Everyone|
|api/department/{id}|HTTP GET|No|Everyone|
|api/department|HTTP POST|Yes|Manager|
|api/department|HTTP PUT|Yes|Manager|
|api/department/{id}|HTTP DELETE|Yes|Manager|
|api/role|HTTP GET|No|Everyone|
|api/role/{id}|HTTP GET|No|Everyone|
|api/role|HTTP POST|Yes|Manager|
|api/role|HTTP PUT|Yes|Manager|
|api/role/{id}|HTTP DELETE|Yes|Manager|
|api/product|HTTP GET|Yes|Manager, Purchasing|
|api/product/{id}|HTTP GET|Yes|Manager, Purchasing|
|api/product|HTTP POST|Yes|Manager, Purchasing|
|api/product|HTTP PUT|Yes|Manager, Purchasing|
|api/product/{id}|HTTP DELETE|Yes|Manager, Purchasing|
