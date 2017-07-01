package test.helpers;

import main.IBunnyWarsStructure;
import org.junit.Before;
import test.BunnyWarsStructureInitializer;

public class BaseTest {
    protected IBunnyWarsStructure BunnyWarCollection;

    @Before
    public void setUp() {
        this.BunnyWarCollection = BunnyWarsStructureInitializer.create();
    }
}
