package test;

import main.BunnyWarsStructure;
import main.IBunnyWarsStructure;

public class BunnyWarsStructureInitializer {

    public static IBunnyWarsStructure create() {
        return new BunnyWarsStructure();
    }
}
