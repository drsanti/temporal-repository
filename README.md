# Guidelines:


`Template`

``` C#
//--- Variable Start -------------------------

//>> REPLACE THIS LINE BY YOUR VARIABLE HERE

//--- Variable End ---------------------------


//--- Method Start ---------------------------

//>> REPLACE THIS LINE BY YOUR METHOD HERE

//--- Method End -----------------------------
```

---

`Evaluation`

Your method will be called from the Form1 constructor as show below.

``` C#
//
// All lines of your code will be copied and pasted here.
//

public Form1()
{
    InitializeComponent();

    // Your method will be called here
    DATA_TYPE VARIABLE = YOUR_METHOD_NAME(PARAMETER_VALUE);
}
```

---

# Example:

**Question:** Write a method named "GenBool" to generate and return a boolean data.

**Your code will look like this:**

```C#
//--- Variable Start -------------------------

Random rnd = new Random();

//--- Variable End ---------------------------


//--- Method Start ---------------------------

private bool GenBool()
{
    return random.Next() % 2 > 0;
}

//--- Method End -----------------------------
```

---


## Evaluation

The evaluator/checker will run your code like this:

```C#

//** All lines of your code will be copied and pasted here.

//--- Variable Start -------------------------

Random rnd = new Random();

//--- Variable End ---------------------------


//--- Method Start ---------------------------

private bool GenBool()
{
    return random.Next() % 2 > 0;
}

//--- Method End -----------------------------


public Form1()
{
    InitializeComponent();

    bool data = GenBool();
}
```