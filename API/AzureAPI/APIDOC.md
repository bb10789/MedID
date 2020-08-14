# MedID API Documentation
The API stores users and interactions in a database and returns user and interaction information back to the user depending on the request.

# All Users
**Request Format:** /UserIds

**Description:** Returns a list of all users in the database.

**Request Type:** GET

**Request Parameters:** None

**Returned Data Format:** JSON

**Example Request:** /UserIds

**Example Response:**
```JSON
[
  {
       "id": 1,
       "fname": "John",
       "lname": "Baker",
       "phone": "(206)-123-4567",
       "email": "johnbaker@gmail.com",
       "location": "Seattle, WA"
   },
   {
       "id": 2,
       "fname": "Sarah",
       "lname": "Hills",
       "phone": "(360)-890-1234",
       "email": "hillssarah@gmail.com",
       "location": "Olympia, WA"
   },
   {
       "id": 3,
       "fname": "Kevin",
       "lname": "Rogers",
       "phone": "(206)-135-7912",
       "email": "kevin@gmail.com",
       "location": "Seattle, WA"
   }
]
```

## Select User ID
**Request Format:** /UserIds/ with query parameter of `id`.

**Description:** Returns user information based on id.

**Request Type:** GET

**Request Parameters:** Query parameter user ID (`id`).

**Returned Data Format:** JSON

**Example Request:** /UserIds/1

**Example Response:**
```JSON
{
     "id": 1,
     "fname": "John",
     "lname": "Baker",
     "phone": "(206)-123-4567",
     "email": "johnbaker@gmail.com",
     "location": "Seattle, WA"
 }
 ```

## Interactions
**Request Format:** /Interactions

**Request Type:** GET

**Request Parameters:** none

**Returned Data Format:** JSON

**Example Request:** /Interactions

**Example Response:**
```JSON
{
    "interactionId": 1,
    "interDate": "2020-07-31T05:12:41.577",
    "id1": 1,
    "id2": 2
},
{
    "interactionId": 3,
    "interDate": "2020-07-30T22:19:40.3",
    "id1": 2,
    "id2": 1
}
```

## Select Interaction ID
**Request Format:** /Interactions/ with query parameter of `id`.

**Description:** Returns interaction information based on id.

**Request Type:** GET

**Request Parameters:** Query parameter of interaction id (`id`).

**Returned Data Format:** JSON

**Example Request:** /Interactions/1

**Example Response:**
```JSON
{
    "interactionId": 1,
    "interDate": "2020-07-31T05:12:41.577",
    "id1": 1,
    "id2": 2
}
```

## Submit Interaction
**Request Format:** /Interactions with JSON as the body. JSON contains `id1` and `id2`.

**Description:** Submits an interaction to be stored in the database and then returns an id and other information on the interaction.

**Request Type:** POST

**Request Parameters:** JSON string with id of person 1 (`id1`) and id of person 2 (`id2`).

**Returned Data Format:** JSON

**Example Request:**
```JSON
{
    "id1": 1,
    "id2": 2
}
```

**Example Response:**
```JSON
{
    "interactionId": 7,
    "interDate": "2020-08-10T09:06:00.4129097+00:00",
    "id1": 1,
    "id2": 2
}
```

## Register User
**Request Format:** /UserIds with JSON as the body. JSON contains `fname`, `lname`, `phone`, `email`, and `location`.

**Description:** Registers a user in the database and then returns the user's information back as well as their id.

**Request Type:** POST

**Request Parameters:** JSON string with first name (`fname`), last name (`lname`), phone number (`phone`), email address (`email`), and location (`location`).

**Returned Data Format:** JSON

**Example Request:**
```JSON
{
     "fname": "John",
     "lname": "Baker",
     "phone": "(206)-123-4567",
     "email": "johnbaker@gmail.com",
     "location": "Seattle, WA"
 }
 ```

 **Example Response:**
 ```JSON
 {
    "id": 7,
    "fname": "John",
    "lname": "Baker",
    "phone": "(206)-123-4567",
    "email": "johnbaker@gmail.com",
    "location": "Seattle, WA"
}
```
