using System;

public class City : Organization {

	public City(){
	}

	public City(string instName) {
		name = instName;
	}

	public void Start() {
		Randomize ();
	}
}