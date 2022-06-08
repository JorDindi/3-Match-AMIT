

[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)


# Match-3 Race

A Match-3 Game, combined with a race.
This project is made for M.A in Computer Science, in Game Development field with Unity. 
#
The project was made with the help of Dor Yahav, Unity Game Developer.



## Roadmap

- Additional browser support

- Add more integrations


## Run Locally

Clone the project

```bash
  git clone https://github.com/JorDindi/3-Match-AMIT
```

Go to the project directory

```bash
  cd 3-match-amit
```

Start the game

```bash
  open match-3-game.exe
```


## API Reference

#### Get all items

```http
  GET /amit-match/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `unlocked` | `true` | Add as many items you want |

#### Get item

```http
  GET /amit-match/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `index`      | `int` | Get specific data on an item |


## Feedback

If you have any feedback, please reach out to us at amityahav12@gmail.com


## Tech Stack

**Client:** Unity Engine

**Server:** UMPS - Pun 2

