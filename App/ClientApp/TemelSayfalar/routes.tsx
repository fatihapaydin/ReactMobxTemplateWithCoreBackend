import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './Layout';
import { Home } from './../Sayfalar/Home';
import { Counter } from './../Sayfalar/Counter';
import { SicaklikSayfa } from "./../Sayfalar/SicaklikSayfa";

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/sicaklik' component={SicaklikSayfa} />
</Layout>;
