import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';

import api from '../services/api'

import Header from '../components/Header';
import '../styles/pages/moviesSelection.css';


function MoviesSelection() {
  const history = useHistory();
  const [movies, setMovies] = useState([]);
  const [moviesCount, setMoviesCount] = useState(0);
  const [selectedMovies, setSelectedMovies] = useState([]);

  //busco os filmes na api
  useEffect(() => {
      api.get('movies').then(response => {
        const moviesApi = response.data;
  
        setMovies(moviesApi);
      }).catch(error => { alert("Erro no servidor, por favor tente novamente mais tarde!") });    
  }, []);

  function setSelectedMovieValue(value) {

    //verifica se o filme selecionado ja foi marcado antes
    const alreadySelected = selectedMovies.findIndex(movie => movie.id === value.id);

    if (alreadySelected >= 0) {
      //se o filme ja foi marcado ele pe retirado da lista de filmes selecionados
      const filteredSelectedMovies = selectedMovies.filter(movie => movie.id !== value.id);
      setSelectedMovies(filteredSelectedMovies);
      //retiro um na quantidade de selecionados
      setMoviesCount(moviesCount - 1);
    } else {
      //se ele não foi marcado eu verifico quantos filmes ja foram selecionados
      if (moviesCount === 8) {
        //se o valor maximo ja tiver sido atingido, aviso o usuario e desmarco o filme selecionado
        alert('Limite de filmes atingido! Caso queira escolher outro, desmarque um dos filmes marcados!');
        document.getElementById(value.id).checked = false;
      } else {
        //se estiver abaixo do valor maximo eu adciono o filme nos filmes selecionados
        setSelectedMovies(selectedMovies => [...selectedMovies, value]);
        //adiciono um na quantidade de selecionados
        setMoviesCount(moviesCount + 1);
      }
    }
  }
  async function handleSubmit(event) {
    event.preventDefault();
    if(moviesCount < 8){
      alert('Por favor selecione 8 filmes para gerar o campeonato!');
    }else{
      history.push({
        pathname: "/finalResult",
        state: { selectedMovies: selectedMovies }
      });
    }
  }
  return (
    <div id="page-movies-selection">
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
                <legend>Selecionados <br />{moviesCount} de 8 filmes</legend>
                <button
                  className="confirm-button"
                  type="submit"
                >
                  <p>Gerar meu Campeonato</p>
                </button> 
              </div>
              <div className="movies-list">

                {movies.map(movie => {
                  return (
                    <div key={movie.id} className="movie-box">
                      <label >
                        <input type="checkbox" id={movie.id} onChange={e => setSelectedMovieValue(movie)} name={movie.id} />
                        <span className="movie-title">{movie.titulo}</span>
                        <span className="movie-year">{movie.ano}</span>
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

export default MoviesSelection;