# MoviesRestAPI

A small WebAPI for fetching, adding and updating movie records using ASP.Net core It consists of three REST API, a brief information on each is given below.

GetMovies (GET) - Fetches the details of all the movies, including name, date of release, producer's information and actor's information 

Sample Response -
[
    {
        "movieId": 1,
        "movieName": "Om Shanti Om",
        "dateOfRelease": "2008-11-09T00:00:00",
        "producers": {
            "producerId": 2,
            "producerName": "Sanjay Leela Bhansali"
        },
        "actors": [
            {
                "actorId": 1,
                "actorName": "Shah Rukh Khan"
            },
            {
                "actorId": 4,
                "actorName": "Katrina Kaif"
            }
        ],
        "error": null
    },
    {
        "movieId": 2,
        "movieName": "Bajirao Mastani",
        "dateOfRelease": "2015-12-18T00:00:00",
        "producers": {
            "producerId": 2,
            "producerName": "Sanjay Leela Bhansali"
        },
        "actors": [
            {
                "actorId": 2,
                "actorName": "Deepika Padukone"
            },
            {
                "actorId": 3,
                "actorName": "Shahid Kapoor"
            }
        ],
        "error": null
    },
    {
        "movieId": 4,
        "movieName": "Jab Tak Hai Jaan",
        "dateOfRelease": "2010-11-09T00:00:00",
        "producers": {
            "producerId": 3,
            "producerName": "Ekta Kapoor"
        },
        "actors": [
            {
                "actorId": 1,
                "actorName": "Shah Rukh Khan"
            },
            {
                "actorId": 4,
                "actorName": "Katrina Kaif"
            }
        ],
        "error": null
    },
    {
        "movieId": 1002,
        "movieName": "Jab We Met",
        "dateOfRelease": "2010-12-19T00:00:00",
        "producers": {
            "producerId": 2,
            "producerName": "Sanjay Leela Bhansali"
        },
        "actors": [
            {
                "actorId": 3,
                "actorName": "Shahid Kapoor"
            },
            {
                "actorId": 4,
                "actorName": "Katrina Kaif"
            }
        ],
        "error": null
    },
    {
        "movieId": 2002,
        "movieName": "3 Idiots",
        "dateOfRelease": "2012-11-09T00:00:00",
        "producers": {
            "producerId": 3,
            "producerName": "Ekta Kapoor"
        },
        "actors": [
            {
                "actorId": 1,
                "actorName": "Shah Rukh Khan"
            },
            {
                "actorId": 3,
                "actorName": "Shahid Kapoor"
            }
        ],
        "error": null
    },
    {
        "movieId": 5003,
        "movieName": "Dhoom 2",
        "dateOfRelease": "2012-11-09T00:00:00",
        "producers": {
            "producerId": 3,
            "producerName": "Ekta Kapoor"
        },
        "actors": [
            {
                "actorId": 1,
                "actorName": "Shah Rukh Khan"
            },
            {
                "actorId": 3,
                "actorName": "Shahid Kapoor"
            }
        ],
        "error": null
    }
]

AddMovie (POST) - Adds a new movie with all the required information provided. 

Sample Request -

{
    "movieName": "Dhoom 2",
        "dateOfRelease": "2012-11-09T00:00:00",
        "producers": {
            "producerId": 3,
            "producerName": "Ekta Kapoor"
        },
        "actors": [
            {
                "actorId": 1,
                "actorName": "Shah Rukh Khan"
            },
            {
                "actorId": 3,
                "actorName": "Shahid Kapoor"
            }
        ]
    }
    
Sample Response -
    
 {
    "success": true,
    "error": null
 }

UpdateMovie (PUT) - Updates a new movie with all the required information needed to be updated. 

Sample Request -

{
        "movieId": 1,
        "movieName": "Om Shanti Om",
        "dateOfRelease": "2008-11-09T00:00:00",
        "producers": {
            "producerId": 2,
            "producerName": "Sanjay Leela Bhansali"
        },
        "actors": [
            {
                "actorId": 1,
                "actorName": "Shah Rukh Khan"
            },
            {
                "actorId": 4,
                "actorName": "Katrina Kaif"
            }
        ]
    }
    
    
  Sample Response -

  {
    "success": true,
    "error": null
}
