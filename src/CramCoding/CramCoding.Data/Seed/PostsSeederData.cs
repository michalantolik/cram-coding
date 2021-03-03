using CramCoding.Domain.Entities;
using System;

namespace CramCoding.Data.Seed
{
    internal class PostsSeederData
    {
        internal readonly Post[] Posts;

        internal PostsSeederData()
        {
            Posts = new Post[]
            {
                new Post
                {
                    Header = "Vestibulum vulputate felis",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ac risus eros. Vivamus condimentum vitae nisl at molestie. Nunc dolor tortor, vulputate eu vestibulum at, vestibulum malesuada enim. Vestibulum vulputate felis quis velit imperdiet, sit amet pulvinar orci vulputate. Pellentesque accumsan odio eu metus luctus, et vulputate sem rutrum. In sollicitudin condimentum ex sed tristique. Ut blandit consequat nibh, venenatis venenatis felis iaculis nec. Praesent convallis nibh sed orci euismod tempor. Etiam ipsum ipsum, faucibus pretium arcu vel, feugiat consectetur lorem. Integer convallis efficitur tincidunt.",
                    CreatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                    UpdatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                    PublishedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                    IsVisible = true,
                    ViewsCount = 23,
                },
                new Post
                {
                    Header = "Mauris sed ipsum lorem",
                    Content = "Ut condimentum non dolor eu sollicitudin. Nulla felis mauris, pulvinar laoreet porttitor vel, aliquet at nibh. Fusce eu ipsum ut ligula feugiat suscipit ut ut libero. Etiam sit amet augue mattis, ornare odio id, consequat felis. Curabitur arcu ex, viverra et dignissim ut, varius eget ligula. Mauris sed ipsum lorem. Suspendisse consequat ante quis scelerisque fermentum. Ut pulvinar, leo sed sagittis scelerisque, tortor nunc aliquet velit, in pretium nisi orci ut tortor. Aliquam tincidunt turpis non elementum faucibus.",
                    CreatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                    UpdatedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                    PublishedAt = new DateTimeOffset(2020, 01, 04, 14, 52, 32, 425, new TimeSpan(2, 0, 0)),
                    IsVisible = true,
                    ViewsCount = 0,
                },
                new Post
                {
                    Header = "Pellentesque habitant morbi",
                    Content = "Mauris non dolor molestie, commodo urna sit amet, imperdiet nisl. Donec sit amet massa posuere, varius nunc non, ultrices nunc. Maecenas consequat maximus est tincidunt volutpat. Nullam eu aliquam quam. Quisque nec pharetra lorem. Nunc sit amet suscipit odio. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis at dapibus lectus. Suspendisse consequat magna vitae sem eleifend consectetur. Fusce at odio sed dui vestibulum posuere. Donec ac ultricies sem.",
                    CreatedAt = new DateTimeOffset(2021, 01, 01, 09, 43, 53, 235, new TimeSpan(2, 0, 0)),
                    UpdatedAt = new DateTimeOffset(2021, 01, 01, 09, 43, 53, 235, new TimeSpan(2, 0, 0)),
                    PublishedAt = new DateTimeOffset(2021, 01, 01, 09, 43, 53, 235, new TimeSpan(2, 0, 0)),
                    IsVisible = true,
                    ViewsCount = 8,
                },
                new Post
                {
                    Header = "Donec auctor enim eu imperdiet molestie",
                    Content = "Donec condimentum a nulla nec ultrices. Suspendisse potenti. Donec auctor enim eu imperdiet molestie. Vivamus et diam malesuada ante tempus convallis. Donec mattis aliquet viverra. Nunc a aliquet nibh. Aenean aliquet tincidunt scelerisque. Donec eu tincidunt neque. Nulla eget tortor a turpis consectetur euismod.",
                    CreatedAt = new DateTimeOffset(2021, 02, 11, 22, 12, 05, 643, new TimeSpan(2, 0, 0)),
                    UpdatedAt = new DateTimeOffset(2021, 02, 11, 22, 12, 05, 643, new TimeSpan(2, 0, 0)),
                    PublishedAt = new DateTimeOffset(2021, 02, 11, 22, 12, 05, 643, new TimeSpan(2, 0, 0)),
                    IsVisible = true,
                    ViewsCount = 53,
                },
                new Post
                {
                    Header = "Vestibulum ornare dignissim vulputate",
                    Content = "Aenean non ex erat. Donec euismod auctor felis auctor faucibus. Morbi lacinia nunc facilisis, pellentesque ipsum nec, tempor quam. Morbi gravida, justo ac hendrerit vulputate, ligula arcu cursus lorem, et gravida metus mi ac risus. Ut in pulvinar leo. Etiam non suscipit elit, vitae imperdiet dui. Vestibulum ornare dignissim vulputate. Praesent ut lobortis nisl. Nunc lorem risus, auctor et pellentesque eu, porttitor ut dolor. Nam nec elit vel metus dictum lobortis. Donec augue augue, ultricies eu lorem id, lacinia malesuada massa. Maecenas libero orci, tincidunt ut sollicitudin ut, tincidunt ac nibh. Maecenas odio diam, imperdiet sit amet tempus at, porttitor aliquet neque. Fusce malesuada, nunc in scelerisque suscipit, sem erat vulputate ante, eu aliquam lectus lorem a enim.",
                    CreatedAt = new DateTimeOffset(2021, 02, 14, 20, 25, 35, 024, new TimeSpan(2, 0, 0)),
                    UpdatedAt = new DateTimeOffset(2021, 02, 14, 20, 25, 35, 024, new TimeSpan(2, 0, 0)),
                    PublishedAt = new DateTimeOffset(2021, 02, 14, 20, 25, 35, 024, new TimeSpan(2, 0, 0)),
                    IsVisible = false,
                    ViewsCount = 523,
                },
            };
        }
    }
}
