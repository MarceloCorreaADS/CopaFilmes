import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import MoviesSelection from './pages/MoviesSelection';

function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={MoviesSelection} />
            </Switch>
        </BrowserRouter>
    );
}

export default Routes;