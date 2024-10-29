# Roman Numeral Converter

A simple converter written in C# to convert roman numerals into integers.  
Also to convert an integer to roman numerals.  

  
Roman numerals are positive only and the maximum number is 3999


### Usage
##### From Roman numerals 
``` 

Console.WriteLine("IX".FromRomanNumerals());  // 9
Console.WriteLine("MCMLXXXIV".FromRomanNumerals());  // 1984
Console.WriteLine("LXXXIX".FromRomanNumerals());  // 89  

```

##### To Roman numerals 
``` 

Console.WriteLine(9.ToRomanNumerals());  // IX
Console.WriteLine(1984.ToRomanNumerals());  // MCMLXXXIV
Console.WriteLine(89.ToRomanNumerals());    // LXXXIX  

```


