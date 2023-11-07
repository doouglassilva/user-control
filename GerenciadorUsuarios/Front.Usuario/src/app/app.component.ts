import { Component, OnInit } from '@angular/core';
import { UsuarioService } from './services/usuario.service';
import { Usuario } from './models/usuario';
import { Escolaridade } from './models/escolaridade';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  usuario: Usuario = {} as Usuario;
  usuarios: Usuario[] = [];
  escolaridades: Escolaridade[] = [];

  constructor(
    private usuarioService: UsuarioService,
  ) {}

  ngOnInit() {
    this.obterTodosUsuarios();
  }

  // Define se um usuário será criado ou atualizado
  salvarUsuario(form: NgForm) {
    if (this.usuario.id) {
      this.usuarioService.atualizarUsuario(this.usuario).subscribe(() => {
        this.cleanForm(form);
      });
    } else {
      this.usuarioService.criarUsuario(this.usuario).subscribe(() => {
        this.cleanForm(form);
      });
    }
  }

  // Chama o serviço para obter todos os usuários
  obterTodosUsuarios() {
    this.usuarioService.obterTodosUsuarios().subscribe((usuarios: Usuario[]) => {
      console.log(usuarios);
      this.usuarios = usuarios;
    });
  }

  // Deleta um usuário
  deletarUsuario(usuario: Usuario) {
    this.usuarioService.excluirUsuario(usuario).subscribe(() => {
      this.obterTodosUsuarios();
    });
  }

  // Copia o usuário para ser editado
  editarUsuario(usuario: Usuario) {
    this.usuario = { ...usuario };
  }

  // Limpa o formulário
  cleanForm(form: NgForm) {
    this.obterTodosUsuarios();
    form.resetForm();
    this.usuario = {} as Usuario;
  }
}
