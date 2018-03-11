package instock;

import java.util.*;
import java.util.stream.Collectors;

public class Instock implements ProductStock {

    private Map<String, Product> products;
    private List<Product> productsByInsert;

    public Instock() {
        this.products = new TreeMap<>();
        this.productsByInsert = new ArrayList<>();
    }

    @Override
    public int getCount() {
        return this.products.size();
    }

    @Override
    public boolean contains(Product product) {
        return this.products.containsKey(product.getLabel());
    }

    @Override
    public void add(Product product) {
        this.products.put(product.getLabel(), product);
        this.productsByInsert.add(product);
    }

    @Override
    public void changeQuantity(String product, int quantity) {
        Product prd = this.findByLabel(product);

        this.productsByInsert.remove(prd);
        prd.setQuantity(quantity);
        this.productsByInsert.add(prd);
    }

    @Override
    public Product find(int index) {
        return this.productsByInsert.get(index);
    }

    @Override
    public Product findByLabel(String label) {
        Product product = this.products.get(label);
        if (product == null) {
            throw new IllegalArgumentException();

        }

        return product;
    }

    @Override
    public Iterable<Product> findFirstByAlphabeticalOrder(int count) {
        if (this.getCount() < count) {
            throw new IllegalArgumentException();
        }

        return this.products.values().stream()
                .sorted(Comparator.comparing(Product::getLabel))
                .limit(count)
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Product> findAllInRange(double lo, double hi) {
        return this.productsByInsert
                .stream()
                .filter(product -> product.getPrice() > lo && product.getPrice() <= hi)
                .sorted((p1, p2) -> Double.compare(p2.getPrice(), p1.getPrice()))
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Product> findAllByPrice(double price) {
        return this.productsByInsert
                .stream()
                .filter(product -> product.getPrice() == price)
                .collect(Collectors.toList());
    }

    @Override
    public Iterable<Product> findFirstMostExpensiveProducts(int count) {
        List<Product> mostExpensive = this.productsByInsert
                .stream()
                .sorted((pr1, pr2) -> Double.compare(pr2.getPrice(), pr1.getPrice()))
                .limit(count)
                .collect(Collectors.toList());

        if (mostExpensive.size() < count) {
            throw new IllegalArgumentException();
        }
        return mostExpensive;
    }

    @Override
    public Iterable<Product> findAllByQuantity(int quantity) {
        return this.productsByInsert
                .stream()
                .filter(pr -> pr.getQuantity() == quantity)
                .collect(Collectors.toList());
    }

    @Override
    public Iterator<Product> iterator() {
        return this.productsByInsert.iterator();
    }
}
