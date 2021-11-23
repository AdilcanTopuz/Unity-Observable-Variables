# ACT On Changed Event | Unity Observable Variables

**Easily detect value change.**

This package I have prepared for game developers in the Unity game engine, you can easily track your variables and run your code as soon as their value changes. It provides performance for your game as you dont need to use "~~Update~~", "~~FixedUpdate~~" or "~~LateUpdate~~" functions.

**_Demo included_**

[Download Unity Package (Google Drive)](https://drive.google.com/file/d/1BQVdUicj-oOLAyOYKWPqD57B9K1upvxP/view?usp=sharing)


## Usage

_Create a cube(Game object) and put this script on it._

<br/>

- Add Namespace:  

```csharp
using Act.Scripts.OnChanged;
```

<br/>

- Replace type to `ObservableVariable<T>`  _(T is your type.  eg: int, bool, string, float etc.. You can even use other data types ("Color", "Vector3"), not only standart data types.)_

```csharp
ObservableVariable<int> health;
```

<br/>

- Define Logger _(When the value of the variable you specified changes, it shows the old and new values in the console.)_

```csharp
ObservableLogger logger;
```

<br/>

- Write in the "Start()" function:

```csharp
void Start()
    {
        health = new ObservableVariable<int>(100); // 100: health value
        health.OnChanged += Health_OnChanged; // After typing "+=", press the "TAB" key 2 times. "OnChanged" function will be created automatically.
        logger = new ObservableLogger(health); // Assign our "health" variable to the "Logger" variable we defined.
    }
	
```

<br/>

"OnChanged" function below was generated automatically.

```csharp
private void Health_OnChanged(object obj)
    {
        
    }
```

<br/>

**That's it, let's write a small scenario. Every time we press the "Space" key, the value of the "health" variable decreases by 10 and when it reaches to 0, cube dying :)**

<br/>

All our code will look like below.

 ```csharp
   ObservableVariable<int> health;
    ObservableLogger logger;

    void Start()
    {
        health = new ObservableVariable<int>(100);
        health.OnChanged += Health_OnChanged;
        logger = new ObservableLogger(health);
    }

    private void Health_OnChanged(object obj)
    {
        if ((int)obj <= 0)
        {
            print("cube is dead");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            health.Value -= 10;
    }
	
 ```
