import React, { useEffect, useState } from "react";
import Category from "./Category";
import { getAllCategories } from "../modules/categoryManager";

const CategoryList = () => {
    const [categories, setCategories] = useState([]);

    const getAll = () => {
        return getAllCategories()
            .then(res => setCategories(res));
    }

    useEffect(() => {
        getAll();
    }, [])

    return (
        <>
            <h2>Categories</h2>
            <div>

                {categories.map((category) =>
                (<Category
                    category={category}
                    key={category.id} />
                ))}
            </div>
        </>
    );
}

export default CategoryList;