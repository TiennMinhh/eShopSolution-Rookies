import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Category from './components/Category';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import AddCategory from './components/AddCategory';
import Product from './components/Product';
import User from './components/User';
import AddProduct from './components/AddProduct';
import AddProductImage from './components/AddProductImage';
import UpdateCategory from './components/UpdateCategory';
import UpdateProduct from './components/UpdateProduct';
import UpdateProductImage from './components/UpdateProductImage ';

import CallbackPage from './components/callback/CallbackPage';
import ProfilePage from './components/profile/ProfilePage';

export default () => (
    <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <Route path="/category/:page?" component={Category} />
        <Route path="/product/:page?" component={Product} />
        <Route path="/user/:page?" component={User} />
        <Route path="/addcategory" component={AddCategory} />
        <Route path="/addproduct" component={AddProduct} />
        <Route path="/updateproduct" component={UpdateProduct} />
        {/*<Route path="/productimage/:page?" component={ProductImage} />*/}
        <Route path="/addproductimage" component={AddProductImage} />
        <Route path="/updateproductimage" component={UpdateProductImage} />
        <Route path="/updatecategory" component={UpdateCategory} />
        <Route path="/fetch-data/:startDateIndex?" component={FetchData} />

        <Route path="/profile" component={ProfilePage} />
        <Route path="/callback" component={CallbackPage} />
    </Layout>
);
