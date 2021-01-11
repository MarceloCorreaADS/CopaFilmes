import React, { useState, useEffect } from 'react';

import api from '../services/api'

import Header from '../components/Header';
import '../styles/pages/moviesSelection.css';


function MovieSelection() {
  async function handleSubmit(event) {
    event.preventDefault();
  }
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    api.get('movies').then(response => { 
        const moviesApi = response.data;

      setMovies(moviesApi);
    })
  }, []);
  return (
    <div id="page-movie-selection">
      <Header
        title="Campeonato de Filmes"
        subtitle="Fase de seleção"
        description="
              Selecione 8 filmes que deseja que entrem na competição e depois pressione o botão Gerar meu Campeonato para prosseguir.
            "
        goBack={false} />
      <div>
        <main>
          <form onSubmit={handleSubmit} className="movies-selection-form">
            <fieldset>
              <div className="top-bar-form">
                <legend>Selecionados <br />0 de 8 filmes</legend>
                <button className="confirm-button" type="submit">
                  Gerar meu Campeonato
                        </button>
              </div>
              <div className="movies-list">
                
              { movies.map(movies => {
                  return(
                    <div key={movies.id}  className="movie-box">
                      <label >
                        <input  type="checkbox" id="idMovie" name="movie" />
                        <span className="movie-title">{movies.titulo}</span>
                        <span className="movie-year">{movies.ano}</span>
                      </label>
                    </div>
                  )
                })}                
              </div>
            </fieldset>
          </form>
        </main>
      </div>
    </div>
  );
}


export default MovieSelection;