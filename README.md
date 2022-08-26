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
| Url | Type | Jwt | Access Role |
| ------------- | ------------- | ------------- | ------------- |
|api/auth|HTTP POST|No|Everyone|
|api/auth/refreshtoken|HTTP POST|No|Everyone|
|api/person|HTTP POST|No|Everyone|
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


W03
Migration is done in the Repository layer.
| Url                            | Type        | Jwt | Access Role | Json Format                                                                                                      |
|--------------------------------|-------------|-----|-------------|------------------------------------------------------------------------------------------------------------------|
| api/Auth                       | HTTP POST   | No  | Everyone    | {"username": "string","password": "string"}                                                                      |
| api/Auth/SignUp                | HTTP POST   | No  | Everyone    | {"name": "string","username": "string","email": "string@mail.com","password": "string"}                          |
| api/Auth/RefreshToken          | HTTP POST   | No  | Everyone    | {"jwtToken": "string","refreshToken": "string"}                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Award                      | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Award/{id}                 | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Award/GetAllData           | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Award/GetDataById/{id}     | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Award                      | HTTP POST   | Yes | Admin       | {"name": "string","awardTypeId": 1}                                                                              |
| api/Award                      | HTTP PUT    | Yes | Admin       | {"id": 1,"name": "string","awardTypeId": 1}                                                                      |
| api/Award/{id}                 | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/AwardType                  | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/AwardType/{id}             | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/AwardType/GetAllData       | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/AwardType/GetDataById/{id} | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/AwardType                  | HTTP POST   | Yes | Admin       | {"name": "string","movieTypeId": 1}                                                                              |
| api/AwardType                  | HTTP PUT    | Yes | Admin       | {"id": 1,"name": "string","movieTypeId": 1}                                                                      |
| api/AwardType/{id}             | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Category                   | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Category/{id}              | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Category/GetAllData        | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Category/GetDataById/{id}  | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Category                   | HTTP POST   | Yes | Admin       | {"name": "string"}                                                                                               |
| api/Category                   | HTTP PUT    | Yes | Admin       | {"id": 1,"name": "string"}                                                                                       |
| api/Category/{id}              | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Director                   | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Director/{id}              | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Director/GetAllData        | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Director/GetDataById/{id}  | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Director                   | HTTP POST   | Yes | Admin       | {"name": "string",birthday": "2022-08-26"}                                                                       |
| api/Director                   | HTTP PUT    | Yes | Admin       | {"id": 1,"name": "string","birthday": "2022-08-26"}                                                              |
| api/Director/{id}              | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Performer                  | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Performer/{id}             | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Performer/GetAllData       | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Performer/GetDataById/{id} | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Performer                  | HTTP POST   | Yes | Admin       | {"name": "string","birthday": "2022-08-26","gender": "string"}                                                   |
| api/Performer                  | HTTP PUT    | Yes | Admin       | {"id": 0,"name": "string","birthday": "2022-08-26","gender": "string"}                                           |
| api/Performer/{id}             | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Producer                   | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Producer/{id}              | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Producer/GetAllData        | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Producer/GetDataById/{id}  | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Producer                   | HTTP POST   | Yes | Admin       | {"name": "string"}                                                                                               |
| api/Producer                   | HTTP PUT    | Yes | Admin       | {"id": 1,"name": "string"}                                                                                       |
| api/Producer/{id}              | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Review                     | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Review/{id}                | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Review                     | HTTP POST   | Yes | Everyone    | {"movieId": 1,"score": 50,"comment": "string"}                                                                   |
| api/Review                     | HTTP PUT    | Yes | Everyone    | {"id": 1,"movieId": 1,"score": 50,"comment": "string"}                                                           |
| api/Review/{id}                | HTTP DELETE | Yes | Everyone    |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Popularity                 | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Popularity/{id}            | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Popularity                 | HTTP POST   | Yes | Admin       | {"movieId": 1}                                                                                                   |
| api/Popularity/{id}            | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/User                       | HTTP GET    | Yes | Admin       |                                                                                                                  |
| api/User/{id}                  | HTTP GET    | Yes | Admin       |                                                                                                                  |
| api/User/GetAllData            | HTTP GET    | Yes | Admin       |                                                                                                                  |
| api/User/GetDataById/{id}      | HTTP GET    | Yes | Admin       |                                                                                                                  |
| api/User/SignUpAdmin           | HTTP POST   | Yes | Admin       | {"name": "string","username": "string","email": "string@mail.com","password": "string"}                          |
| api/User                       | HTTP PUT    | Yes | Admin       | {"id": 1,"name": "string","username": "string","email": "string@mail.com","password": "string","roleId": 1}      |
| api/User/{id}                  | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Movie                      | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Movie/{id}                 | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Movie/GetAllData           | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Movie/GetDataById/{id}     | HTTP GET    | Yes | Everyone    |                                                                                                                  |
| api/Movie                      | HTTP POST   | Yes | Admin       | {"name": "string","movieTypeId": 1,"releaseDate": "2022-08-26","budget": 100,"gross": 100}                       |
| api/Movie                      | HTTP PUT    | Yes | Admin       | {"id": 1,"name": "string","movieTypeId": 1,"releaseDate": "2022-08-26T11:10:50.036Z","budget": 100,"gross": 100} |
| api/Movie/{id}                 | HTTP DELETE | Yes | Admin       |                                                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Movie/AddCategory          | HTTP POST   | Yes | Admin       | {"movieId": 1,"categoryId": 1}                                                                                   |
| api/Movie/DeleteCategory       | HTTP DELETE | Yes | Admin       | {"movieId": 1,"categoryId": 1}                                                                                   |
|                                |             |     |             |                                                                                                                  |
| api/Movie/AddPerformer         | HTTP POST   | Yes | Admin       | {"movieId": 1,"performerId": 1}                                                                                  |
| api/Movie/DeletePerformer      | HTTP DELETE | Yes | Admin       | {"movieId": 1,"performerId": 1}                                                                                  |
|                                |             |     |             |                                                                                                                  |
| api/Movie/AddDirector          | HTTP POST   | Yes | Admin       | {"movieId": 1,"directorId": 1}                                                                                   |
| api/Movie/DeleteDirector       | HTTP DELETE | Yes | Admin       | {"movieId": 1,"directorId": 1}                                                                                   |
|                                |             |     |             |                                                                                                                  |
| api/Movie/AddProducer          | HTTP POST   | Yes | Admin       | {"movieId": 1,"producerId": 1}                                                                                   |
| api/Movie/DeleteProducer       | HTTP DELETE | Yes | Admin       | {"movieId": 1,"producerId": 1}                                                                                   |
|                                |             |     |             |                                                                                                                  |
| api/Movie/AddAward             | HTTP POST   | Yes | Admin       | {"date": "2022-08-26","movieId": 1,"awardId": 1,"directorId": 0,"performerId": 0}                                |
| api/Movie/DeleteAward          | HTTP DELETE | Yes | Admin       | {"movieId": 1,"awardId": 1}                                                                                      |



